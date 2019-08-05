import { createReducer, on } from '@ngrx/store';

export const initialState = {
  access_token: '',
  expires_in: '',
  token_type:  '',
  refresh_token: '',
  scope: ''
};


export const autorizacaoReducer = createReducer();
