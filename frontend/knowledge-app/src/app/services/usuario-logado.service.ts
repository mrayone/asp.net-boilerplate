import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TokenModel } from './config/models/models';
import { Store, select } from '@ngrx/store';
import { AppState } from '../state-manager/reducers';
import { ObterTokenModel } from '../state-manager/selectors/token.selector';
import { jwtParser } from '../Utils/jwtParser';

@Injectable({
  providedIn: 'root'
})
export class UsuarioLogadoService {
  tokenModel$: Observable<TokenModel>;
  constructor(private store: Store<AppState>) {
    this.tokenModel$ = store.pipe(select(ObterTokenModel));
   }
}

export class UsuarioViewModel {
  nome: string;
  email: string;

  constructor() {
    this.nome = '';
    this.email = '';
  }
}
