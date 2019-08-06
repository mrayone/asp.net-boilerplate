import { createReducer, on, State } from '@ngrx/store';
import { AutorizacaoActions, AutorizacaoTypes, ReaverToken } from '../../actions/autorizacao/autorizacao.actions';
import { TokenModel } from 'src/app/services/config/models/models';

const LOGIN_KEY = 'USUARIO_TOKEN';

export const initialState: TokenModel = new TokenModel();

export function reducer(state =  initialState, action: AutorizacaoActions) {
    switch (action.type) {
      case AutorizacaoTypes.Login:
        return setLoginState(action.payload);
      case AutorizacaoTypes.Logout:
        return removeLoginState(state);
      case AutorizacaoTypes.ReaverToken:
        return reaverToken(state);
    }
}

function setLoginState(state =  initialState) {
    localStorage.setItem(LOGIN_KEY, JSON.stringify(state));

    return state;
}

function removeLoginState(state =  initialState) {
  localStorage.removeItem(LOGIN_KEY);
  state =  new TokenModel();
  return state;
}

function reaverToken(state = initialState) {
  const stringTokenModel = localStorage.getItem(LOGIN_KEY);
  try {
    state = JSON.parse(stringTokenModel) as TokenModel;
  } catch {
    return initialState;
  }
  return state;
}
