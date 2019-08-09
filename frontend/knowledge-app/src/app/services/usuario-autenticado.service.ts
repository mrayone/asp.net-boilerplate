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
export class UsuarioAutenticadoService {

  private tokenModel$: Observable<TokenModel>;
  constructor(private store: Store<AppState>) {
    this.tokenModel$ = store.pipe(select(ObterTokenModel));
  }

  getAuthorizationToken(): TokenModel {
    let token: TokenModel;
    this.tokenModel$.subscribe(model => {
      if (model) { token = model; }
    });

    return token;
  }
}

export class UsuarioViewModel {
  nome: string;
  sobrenome: string;
  email: string;
  sub: string;
  permissions: [];

  constructor() {
    this.nome = '';
    this.email = '';
    this.permissions = [];
    this.sub = '';
    this.sobrenome = '';
  }
}
