import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { logging } from 'protractor';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { url } from './config/config';
import { AppState } from '../state-manager/reducers';
import { Store, select } from '@ngrx/store';
import { ObterTokenModel } from '../state-manager/selectors/token.selector';
import { jwtParser } from '../Utils/jwtParser';
import { ReaverToken } from '../state-manager/actions/autorizacao/autorizacao.actions';
import { TokenModel, GrantAcessModel } from './config/models/models';

const httpOptions = {
  headers: new HttpHeaders({'Content-Type': 'application/x-www-form-urlencoded'})
};

@Injectable({
  providedIn: 'root'
})
export class LogInService {

  private tokenModel: TokenModel;
  constructor(private http: HttpClient, private stateManager: Store<AppState>) {
    stateManager.pipe(select(ObterTokenModel)).subscribe(model => this.tokenModel = model);
  }

  getTokenAcesso( grantAcess: GrantAcessModel): Observable<TokenModel> {
      return this.http.post(`${url}/connect/token`, grantAcess , httpOptions)
      .pipe(
        catchError(this.handleError<any>('obterToken'))
      );
  }

  hasToken(): boolean {
    let hasToken = false;
    this.stateManager.dispatch(new ReaverToken());
    this.stateManager.pipe(select(ObterTokenModel))
    .subscribe(token => {
      hasToken = !!token;
    });

    return hasToken;
  }

   validarToken() {
    const httpOptions = {
      headers: new HttpHeaders({
          'Content-Type': 'application/x-www-form-urlencoded',
          'Authorization': `Basic ${btoa('api:hello')}`
      })
    };
    const token = this.tokenModel.access_token;
    const postModel = new HttpParams({fromObject: { token }});

    return this.http.post(`${url}/connect/introspect`, postModel , httpOptions)
      .pipe(
        catchError(this.handleError<any>('validarToken'))
        ).subscribe(value => {
            if (!value['active']) {
              this.refreshToken();
            }
            return value;
        });
  }

  refreshToken() {
    const refresh_token = this.tokenModel.refresh_token;
    const postModel = new HttpParams({fromObject: {
      grant_type: 'refresh_token',
      client_id : 'spa.client',
      refresh_token
    }});
    return this.http.post(`${url}/connect/token`, postModel , httpOptions)
      .pipe(
        catchError(this.handleError<any>('validarToken'))
        ).subscribe(value => {
            console.log(value);
        });
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: {}): Observable<T> => {
      // Let the app keep running by returning an empty result.
      console.error(error);
      return of(result as T);
    };
  }
}

