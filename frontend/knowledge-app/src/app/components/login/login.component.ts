import { AfterViewInit, Component, ElementRef, OnInit, ViewChildren } from '@angular/core';
import { FormControl, FormControlName, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { select, Store } from '@ngrx/store';
import { fromEvent, merge, Observable } from 'rxjs';
import { GrantAcessModel, TokenModel } from 'src/app/services/config/models/models';
import { LogInService } from 'src/app/services/log-in.service';
import { Autorizacao } from 'src/app/store/actions/app.actions';
import { AppState } from 'src/app/store/reducers';
import { ObterTokenModel } from 'src/app/store/selectors/app.selector';
import { GenericValidator } from 'src/app/Utils/generic-validator';
import { mensagensDeErro } from './mensgens-de-erro/mensagens';
import { InrequestService } from 'src/app/services/inrequest.service';


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

  constructor(private loginService: LogInService, private stateService: Store<AppState>, public inRequestService: InrequestService,
     private router: Router) {
    this.genericValidator = new GenericValidator(mensagensDeErro);
  }

  autenticarUsuario(): void {
    if (this.loginForm.valid) {
      const model = new GrantAcessModel(this.loginForm.value.username,
        this.loginForm.value.password);
      this.loginService.getTokenAcesso(model).subscribe(response => {
        if (response) {
          this.loginComplete(response);
        }
      });
    }
  }

  loginComplete(response: TokenModel) {
    this.stateService.dispatch(new Autorizacao({auth: response}));
    this.router.navigate(['dashboard']);
  }

  ngOnInit() {
    this.formInit();
    this.stateInit();
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

  ngAfterViewInit(): void {
    const controlBlurs: Observable<any>[] = this.formInputElements
      .map((formControl: ElementRef) => fromEvent(formControl.nativeElement, 'blur'));

    merge(...controlBlurs).subscribe(value => {
      this.erros = this.genericValidator.processMessages(this.loginForm);
    });
  }
}
