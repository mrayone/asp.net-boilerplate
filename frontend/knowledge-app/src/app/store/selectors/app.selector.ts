import { AppState } from '../reducers';
import { createSelector } from '@ngrx/store';

export const selectorAppState = (state: AppState) => state.appState;

export const ObterTokenModel = createSelector(
    selectorAppState,
    store => store.auth
);

export const InRequest = createSelector(
  selectorAppState,
  state => state.inRequest
);
