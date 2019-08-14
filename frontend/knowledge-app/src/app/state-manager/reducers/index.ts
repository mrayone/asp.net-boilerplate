import {
  ActionReducerMap, MetaReducer,
} from '@ngrx/store';
import { environment } from '../../../environments/environment';
import * as fromUser from './autorizacao.reducer';
import { TokenModel } from 'src/app/services/config/models/models';

export interface AppState {
  autorizacaoState: TokenModel;
}

export const reducers: ActionReducerMap<AppState> = {
  autorizacaoState: fromUser.reducer
};


export const metaReducers: MetaReducer<AppState>[] = !environment.production ? [] : [];
