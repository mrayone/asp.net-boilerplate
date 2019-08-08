import { Component, OnInit, AfterViewInit, ViewChildren, ElementRef, ViewChild } from '@angular/core';
import { FormGroup, FormControlName, Validators, FormControl } from '@angular/forms';
import { GenericValidator } from 'src/app/Utils/generic-validator';
import { merge, Observable, fromEvent } from 'rxjs';
import { LogInService } from 'src/app/services/log-in.service';
import { Store, select } from '@ngrx/store';
import { AppState } from 'src/app/state-manager/reducers';
import { Autorizacao } from 'src/app/state-manager/actions/autorizacao/autorizacao.actions';
import { mensagensDeErro } from './mensgens-de-erro/mensagens';
import { ToastrService } from 'ngx-toastr';

import { Router } from '@angular/router';
import { ObterTokenModel } from 'src/app/state-manager/selectors/token.selector';
import { GrantAcessModel, TokenModel } from 'src/app/services/config/models/models';
import { ErrosService } from 'src/app/services/erros.service';
import { take } from 'rxjs/operators';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit, AfterViewInit {
  loginForm: FormGroup;
  inRequest = false;
  errosDeRequest: string[];

  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];
  genericValidator: GenericValidator;
  erros?: { [key: string]: string } = {};

  constructor(private loginService: LogInService, private stateService: Store<AppState>, private router: Router,
     private erroService: ErrosService, private toastrService: ToastrService) {
    this.genericValidator = new GenericValidator(mensagensDeErro);
    this.errosDeRequest = [];
  }

  autenticarUsuario(): void {
    if (this.loginForm.dirty && this.loginForm.valid) {
      const model = new GrantAcessModel(this.loginForm.value.username,
         this.loginForm.value.password);
      this.inRequest = true;
      this.loginService.getTokenAcesso(model).subscribe(response => {
          if (response) {
            this.loginComplete(response);
          }
          this.checarErrosDeRequest();
          this.inRequest = false;
      });
    }
  }

  checarErrosDeRequest() {
    if (this.errosDeRequest.length > 0) {
      const erros = this.errosDeRequest.reduce((acc, next) => {
        return `<p>${acc}</p>` + `<p>${next}</p>`;
      });
      this.toastrService.error(erros, 'Erros', {
        enableHtml: true,
        disableTimeOut: true
      }).onTap.pipe(take(1))
      .subscribe(() => this.close());
    }
  }

  loginComplete(response: TokenModel) {
      this.stateService.dispatch(new Autorizacao(response));
      this.router.navigate(['dashboard']);
  }

  ngOnInit() {
    this.formInit();
    this.stateInit();
    this.subscribeErros();
  }

  private stateInit() {
    this.stateService.pipe(select(ObterTokenModel))
    .subscribe(token => {
      if (token) {
        this.router.navigate(['/dashboard']);
      }
    });
  }

  private formInit() {
    this.loginForm = new FormGroup({
      username: new FormControl('', [Validators.email, Validators.required]),
      password: new FormControl('', Validators.required)
    });
  }

  private subscribeErros() {
    this.erroService.getErros().subscribe(erros => {
      this.errosDeRequest = erros;
    });
  }

  close() {
    this.erroService.limparErros();
  }

  ngAfterViewInit(): void {
    const controlBlurs: Observable<any>[] = this.formInputElements
    .map((formControl: ElementRef) => fromEvent(formControl.nativeElement, 'blur'));

    merge(...controlBlurs).subscribe(value => {
      this.erros = this.genericValidator.processMessages(this.loginForm);
    });
  }

}
