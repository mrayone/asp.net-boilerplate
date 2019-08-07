import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ErrosService {

  errosMessage$: Observable<string[]>;
  constructor() { }


  adicionarErro(mensagem: string) {
    this.errosMessage$.subscribe(erros => {
      erros.push(this.traduzirMensagem(mensagem));
    });
  }

  limparErros() {
    this.errosMessage$.subscribe(erros => {
      erros = [];
    });
  }

  private traduzirMensagem(mensagem: string): string {
      switch (mensagem) {
        case 'invalid_username_or_password':
          return 'E-mail ou senha inválidos.';
        default:
          if (mensagem) { return mensagem; } else { return 'Ocorreu algum erro.'; }
      }
  }
}
