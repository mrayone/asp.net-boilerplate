import { Component, OnInit, AfterViewInit, ViewChildren, ElementRef } from '@angular/core';
import { FormGroup, FormControlName, Validators, FormControl } from '@angular/forms';
import { GenericValidator } from 'src/app/Utils/generic-validator';
import { merge, Observable, fromEvent } from 'rxjs';
import { LogInService, GrantAcessModel, TokenModel } from 'src/app/services/log-in.service';
import { Store } from '@ngrx/store';
import { AppState } from 'src/app/state-manager/reducers';
import { Autorizacao } from 'src/app/state-manager/actions/autorizacao/autorizacao.actions';
import { mensagensDeErro } from './mensgens-de-erro/mensagens';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit, AfterViewInit {
  loginForm: FormGroup;

  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];
  genericValidator: GenericValidator;
  erros?: { [key: string]: string } = {};

  constructor(private loginService: LogInService, private stateService: Store<AppState>) {
    this.genericValidator = new GenericValidator(mensagensDeErro);
  }

  autenticarUsuario(): void {
    if (this.loginForm.dirty && this.loginForm.valid) {
      const model = new GrantAcessModel(this.loginForm.value.username,
         this.loginForm.value.password);

      this.loginService.getTokenAcesso(model).subscribe(response => {
          this.loginComplete(response);
      });
    }
  }
  loginComplete(response: TokenModel) {
      this.stateService.dispatch(new Autorizacao(response));
  }

  ngOnInit() {
    this.loginForm = new FormGroup({
      username: new FormControl('', [Validators.email, Validators.required]),
      password: new FormControl('', Validators.required)
    });
  }

  ngAfterViewInit(): void {
    const controlBlurs: Observable<any>[] = this.formInputElements
    .map((formControl: ElementRef) => fromEvent(formControl.nativeElement, 'blur'));

    merge(...controlBlurs).subscribe(value => {
      this.erros = this.genericValidator.processMessages(this.loginForm);
    });
  }

}
