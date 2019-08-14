import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ErrosService {

  private errosMessage$: Observable<string[]>;
  private erros: string[];
  constructor( private toastrService: ToastrService) {
    this.erros = [];
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
        return 'Ocorreu algum erro, tente novamente mais tarde.';
      default:
        if (mensagem) { return mensagem; } else { return 'Ocorreu algum erro.'; }
    }
  }
}
