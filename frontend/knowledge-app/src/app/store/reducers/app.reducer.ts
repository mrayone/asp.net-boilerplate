import { createReducer, on, State } from '@ngrx/store';
import { AppActions, AppTypes, ReaverToken } from '../actions/app.actions';
import { TokenModel } from 'src/app/services/config/models/models';

export const LOGIN_KEY = 'USUARIO_TOKEN';

export interface StateApp {
  auth: TokenModel;
}

export const initialState: StateApp = {
  auth: new TokenModel()
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
  }
}

function setLoginState(state = initialState) {
  localStorage.setItem(LOGIN_KEY, JSON.stringify(state.auth));

  return state;
}

function removeLoginState() {
  localStorage.removeItem(LOGIN_KEY);
  return initialState;
}

function reaverToken(state = initialState) {
  const stringTokenModel = localStorage.getItem(LOGIN_KEY);
  state.auth = JSON.parse(stringTokenModel) as TokenModel;
  return state;
}
