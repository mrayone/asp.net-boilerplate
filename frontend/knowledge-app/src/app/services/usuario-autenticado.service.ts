import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TokenModel } from './config/models/models';
import { Store, select } from '@ngrx/store';
import { AppState } from '../store/reducers';
import { ObterTokenModel } from '../store/selectors/app.selector';
import { jwtParser } from '../Utils/jwtParser';
import { RefreshToken, Logout } from '../store/actions/app.actions';
import { LogInService } from './log-in.service';

@Injectable({
  providedIn: 'root'
})
export class UsuarioAutenticadoService {

  private tokenModel$: Observable<TokenModel>;
  constructor(private store: Store<AppState>, private loginService: LogInService) {
    this.tokenModel$ = store.pipe(select(ObterTokenModel));
  }

  getAuthorizationToken(): TokenModel {
    let token: TokenModel;
    this.tokenModel$.subscribe(model => {
      if (model) { token = model; }
    });
    return token;
  }

  tokenExpirou(access_token: string): boolean {
    // tslint:disable-next-line: no-shadowed-variable
    const { exp } = jwtParser(access_token) as any;
    const dateExpire = new Date(exp * 1000);
    return dateExpire < new Date();
  }

  refreshToken(tkModel: TokenModel): void {
    this.loginService.refreshToken().subscribe(model => {
      if (model) {
        tkModel = model;
        this.store.dispatch(new RefreshToken({ auth: model }));
      }
    });
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
