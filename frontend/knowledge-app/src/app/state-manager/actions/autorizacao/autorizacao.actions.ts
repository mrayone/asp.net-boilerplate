import { createAction, Action } from '@ngrx/store';
import { TokenModel } from 'src/app/services/log-in.service';


export enum AutorizacaoTypes {
  Login = '[Autorização Component] Login',
  RefreshToken = '[Autorização Component] Refresh Token',
  Logout = '[Autorização Component] Logout',
}

export class Login implements Action {
  readonly type = AutorizacaoTypes.Login;

  constructor(public payload: TokenModel) { }
}

export class RefreshToken implements Action {
  readonly type = AutorizacaoTypes.RefreshToken;
  constructor(public payload: TokenModel) { }
}
export class Logout implements Action {
  readonly type = AutorizacaoTypes.Logout;

  constructor() { }
}

export type AutorizacaoActions = Login | RefreshToken | Logout;
