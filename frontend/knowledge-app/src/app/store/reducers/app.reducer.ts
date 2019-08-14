import { createReducer, on, State } from '@ngrx/store';
import { AppActions, AppTypes, ReaverToken } from '../actions/app.actions';
import { TokenModel } from 'src/app/services/config/models/models';

export const LOGIN_KEY = 'USUARIO_TOKEN';

export interface StateApp {
  auth: TokenModel;
  inRequest: boolean;
}

export const initialState: StateApp = {
  auth: new TokenModel(),
  inRequest: false
};

export function reducer(state = initialState, action: AppActions) {
  switch (action.type) {
    case AppTypes.RefreshToken:
      window.location.reload();
      return setLoginState(action.payload);
    case AppTypes.Login:
      return setLoginState(action.payload);
    case AppTypes.Logout:
      return removeLoginState();
    case AppTypes.ReaverToken:
      return reaverToken(state);
    case AppTypes.RequestProgress:
      state.inRequest = true;
      return state;
    case AppTypes.RequestStopped:
      state.inRequest = false;
      return state;
  }
}

function setLoginState(state = initialState) {
  localStorage.setItem(LOGIN_KEY, JSON.stringify(state.auth));

  return state;
}

function removeLoginState(state = initialState) {
  localStorage.removeItem(LOGIN_KEY);
  return null;
}

function reaverToken(state = initialState) {
  const stringTokenModel = localStorage.getItem(LOGIN_KEY);
  state.auth = JSON.parse(stringTokenModel) as TokenModel;
  state.inRequest = false;
  return state;
}
