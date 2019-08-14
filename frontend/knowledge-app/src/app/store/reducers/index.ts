import {
  ActionReducerMap, MetaReducer,
} from '@ngrx/store';
import { environment } from '../../../environments/environment';
import * as fromUser from './app.reducer';
import { TokenModel } from 'src/app/services/config/models/models';

export interface AppState {
  appState: fromUser.StateApp;
}

export const reducers: ActionReducerMap<AppState> = {
  appState: fromUser.reducer
};


export const metaReducers: MetaReducer<AppState>[] = !environment.production ? [] : [];
