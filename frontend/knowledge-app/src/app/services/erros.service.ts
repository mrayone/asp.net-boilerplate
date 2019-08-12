import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { AppState } from '../state-manager/reducers';
import { Store } from '@ngrx/store';
import { Logout } from '../state-manager/actions/autorizacao/autorizacao.actions';

@Injectable({
  providedIn: 'root'
})
export class ErrosService {

  private errosMessage$: Observable<string[]>;
  private erros: string[];
  constructor(private stateManager: Store<AppState>) {
    this.erros =  [];
    this.errosMessage$ = new Observable((observer) => observer.next(this.erros));
  }

  adicionarErro(mensagem: string) {
    this.errosMessage$.subscribe(erros => erros.push(this.traduzirMensagem(mensagem)));
  }

  adicionarRange(array: []) {
    this.errosMessage$.subscribe(erros => {
        erros.push(...array);
    });
  }

  getErros(): Observable<string[]> {
    return this.errosMessage$;
  }

  limparErros() {
    this.errosMessage$.subscribe(erros => erros.length = 0);
  }

  private traduzirMensagem(mensagem: string): string {

      switch (mensagem) {
        case 'invalid_username_or_password':
          return 'E-mail ou senha inválidos.';
        case 'invalid_grant':
          this.stateManager.dispatch(new Logout());
          return 'Ocorreu algum erro, tente novamente mais tarde.';
        default:
          if (mensagem) { return mensagem; } else { return 'Ocorreu algum erro.'; }
      }
  }
}
