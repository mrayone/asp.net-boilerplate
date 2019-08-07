import { Component, OnInit, AfterViewInit, ViewChildren, ElementRef } from '@angular/core';
import { FormGroup, FormControlName, Validators, FormControl } from '@angular/forms';
import { GenericValidator } from 'src/app/Utils/generic-validator';
import { merge, Observable, fromEvent } from 'rxjs';
import { LogInService } from 'src/app/services/log-in.service';
import { Store, select } from '@ngrx/store';
import { AppState } from 'src/app/state-manager/reducers';
import { Autorizacao } from 'src/app/state-manager/actions/autorizacao/autorizacao.actions';
import { mensagensDeErro } from './mensgens-de-erro/mensagens';

import { Router } from '@angular/router';
import { ObterTokenModel } from 'src/app/state-manager/selectors/token.selector';
import { GrantAcessModel, TokenModel } from 'src/app/services/config/models/models';
import { ErrosService } from 'src/app/services/erros.service';

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
     private erroService: ErrosService) {
    this.genericValidator = new GenericValidator(mensagensDeErro);
    this.errosDeRequest = [];
  }

  autenticarUsuario(): void {
    if (this.loginForm.dirty && this.loginForm.valid) {
      const model = new GrantAcessModel(this.loginForm.value.username,
         this.loginForm.value.password);
      this.inRequest = true;
      this.loginService.getTokenAcesso(model).subscribe(response => {
          if(response){
            this.loginComplete(response);
          }
          this.inRequest = false;
      });
    }
  }
  loginComplete(response: TokenModel) {
      this.stateService.dispatch(new Autorizacao(response));
      this.router.navigate(['dashboard']);
  }

  ngOnInit() {
    this.loginForm = new FormGroup({
      username: new FormControl('', [Validators.email, Validators.required]),
      password: new FormControl('', Validators.required)
    });

    this.stateService.pipe(select(ObterTokenModel))
    .subscribe(token => {
      if (token) {
        this.router.navigate(['/dashboard']);
      }
    });

    this.subscribeErros();
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
