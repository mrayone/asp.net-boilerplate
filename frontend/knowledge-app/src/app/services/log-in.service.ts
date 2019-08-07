import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { logging } from 'protractor';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { url } from './config/config';
import { AppState } from '../state-manager/reducers';
import { Store, select } from '@ngrx/store';
import { jwtParser } from '../Utils/jwtParser';
import { Logout, RefreshToken } from '../state-manager/actions/autorizacao/autorizacao.actions';
import { TokenModel, GrantAcessModel } from './config/models/models';
import { LOGIN_KEY } from '../state-manager/reducers/autorizacao/autorizacao.reducer';

const httpOptions = {
  headers: new HttpHeaders({'Content-Type': 'application/x-www-form-urlencoded'})
};

@Injectable({
  providedIn: 'root'
})
export class LogInService {

  constructor(private http: HttpClient, private stateManager: Store<AppState>) {
  }

  getTokenAcesso( grantAcess: GrantAcessModel): Observable<TokenModel> {
      return this.http.post(`${url}/connect/token`, grantAcess , httpOptions)
      .pipe(
        catchError(this.handleError<any>('obterToken'))
      );
  }

  hasToken(): boolean {
    const hasToken = !!localStorage.getItem(LOGIN_KEY);

    if (!hasToken) {
      this.stateManager.dispatch(new Logout());
    }

    return hasToken;
  }

   validarToken() {
    // tslint:disable-next-line: no-shadowed-variable
    const { exp } = jwtParser(this.getTokenModel().access_token) as any;
    const dateExpire = new Date( exp * 1000 );
    const tokenExpirou = dateExpire < new Date();
    if ( tokenExpirou ) {
      this.introspectToken().subscribe(value => {
        if ( !value.active ) {
          this.refreshToken().subscribe(response => {
            const tokenModel = response as TokenModel;
            if (tokenModel) {
              this.stateManager.dispatch(new RefreshToken(tokenModel));
            } else {
              this.stateManager.dispatch(new Logout());
            }
        });
        }
      });
    }
  }

  private introspectToken(): Observable<IntrospectModel> {
    // tslint:disable-next-line: no-shadowed-variable
    const httpOptions = {
      headers: new HttpHeaders({
          'Content-Type': 'application/x-www-form-urlencoded',
          Authorization: `Basic ${btoa('api:hello')}`
      })
    };
    const token = this.getTokenModel().access_token;
    const postModel = new HttpParams({fromObject: { token }});

    return this.http.post(`${url}/connect/introspect`, postModel , httpOptions)
      .pipe(
        catchError(this.handleError<any>('validarToken'))
        );
  }

  refreshToken() {
    try {
      const refresh_token = this.getTokenModel().refresh_token;
      const postModel = new HttpParams({fromObject: {
        grant_type: 'refresh_token',
        client_id : 'spa.client',
        refresh_token
      }});
      return this.http.post(`${url}/connect/token`, postModel , httpOptions)
      .pipe(
        catchError(this.handleError<any>('validarToken'))
        );
    } catch {

    }
  }

  private getTokenModel(): TokenModel {
      if (!this.hasToken()) return null;

      const user = localStorage.getItem(LOGIN_KEY);
      const tokenModel: TokenModel = JSON.parse(user) as TokenModel;
      return tokenModel;
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: {}): Observable<T> => {
      // Let the app keep running by returning an empty result.
      console.error(error);
      return of(result as T);
    };
  }
}


export class IntrospectModel {
  active = false;
}
