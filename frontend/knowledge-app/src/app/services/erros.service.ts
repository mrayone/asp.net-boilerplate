import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs/operators';
import { Store } from '@ngrx/store';
import { AppState } from '../store/reducers';
import { Logout } from '../store/actions/app.actions';

@Injectable({
  providedIn: 'root'
})
export class ErrosService {

  constructor( private toastrService: ToastrService, private store: Store<AppState>) {
  }

  dispararErro(mensagem: string) {
    const msg = this.traduzirMensagem(mensagem);
    this.toastrService.error(msg, 'Erros', {
      enableHtml: true,
      disableTimeOut: true
    }).onTap.pipe(take(1));
  }

  dispararRangeErros(mensagem: string[]) {
    const msg = mensagem.reduce((ac, next) => {
      return `<p>${ac}</p>` + `<p>${next}</p>`;
    });
    this.toastrService.error(msg, 'Erros', {
      enableHtml: true,
      disableTimeOut: true
    }).onTap.pipe(take(1));
  }


  private traduzirMensagem(mensagem: string): string {

    switch (mensagem) {
      case 'invalid_username_or_password':
        return 'E-mail ou senha inválidos.';
      case 'invalid_grant':
        this.store.dispatch(new Logout());
        return 'Ocorreu algum erro, tente novamente mais tarde.';
      default:
        if (mensagem) { return mensagem; } else { return 'Ocorreu algum erro.'; }
    }
  }
}
