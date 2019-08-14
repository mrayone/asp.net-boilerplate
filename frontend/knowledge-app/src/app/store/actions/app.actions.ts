import { createAction, Action } from '@ngrx/store';
import { TokenModel } from 'src/app/services/config/models/models';
import { StateApp } from '../reducers/app.reducer';


export enum AppTypes {
  Login = '[Autorização Component] Login',
  RefreshToken = '[Autorização Component] Refresh Token',
  Logout = '[Autorização Component] Logout',
  ReaverToken = '[Autorização Component] ReaverToken'
}

export class Autorizacao implements Action {
  readonly type = AppTypes.Login;

  constructor(public payload: StateApp) { }
}

export class RefreshToken implements Action {
  readonly type = AppTypes.RefreshToken;
  constructor(public payload: StateApp ) { }
}

export class Logout implements Action {
  readonly type = AppTypes.Logout;

  constructor() { }
}

export class ReaverToken implements Action {
  readonly type = AppTypes.ReaverToken;

  constructor() { }
}

export type AppActions = Autorizacao | RefreshToken | Logout | ReaverToken;
