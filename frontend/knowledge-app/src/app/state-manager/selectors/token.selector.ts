import { AppState } from '../reducers';
import { createSelector } from '@ngrx/store';

export const selectorAutorizacaoState = (state: AppState) => state.autorizacaoState;

export const ObterTokenModel = createSelector(
    selectorAutorizacaoState,
    token => token
);
