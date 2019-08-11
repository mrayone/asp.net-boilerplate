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
import { Logout, RefreshToken } from '../state-manager/actions/autorizacao/autorizacao.actions';
import { TokenModel, GrantAcessModel } from './config/models/models';
import { LOGIN_KEY } from '../state-manager/reducers/autorizacao/autorizacao.reducer';
import { ErrosService } from './erros.service';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/x-www-form-urlencoded' })
};

@Injectable({
  providedIn: 'root'
})
export class LogInService {

  private tokenModel: TokenModel;
  constructor(private http: HttpClient, private stateManager: Store<AppState>, private erros: ErrosService) {
    stateManager.pipe(select(ObterTokenModel)).subscribe(model => this.tokenModel = model);
  }

  getTokenAcesso(grantAcess: GrantAcessModel): Observable<TokenModel> {
    return this.http.post(`${url}/connect/token`, grantAcess, httpOptions)
      .pipe(
        catchError(this.handleError<any>('obterToken'))
      );
  }

  hasToken(): boolean {
    const hasToken = !!localStorage.getItem(LOGIN_KEY);
    const hasTokenInState = !!this.tokenModel;
    if (!hasToken || !hasTokenInState) {
      this.stateManager.dispatch(new Logout());
      return false;
    }

    return hasToken;
  }

  validateToken() {
    // tslint:disable-next-line: no-shadowed-variable
    const { exp } = jwtParser(this.tokenModel.access_token) as any;
    const dateExpire = new Date(exp * 1000);
    const tokenExpirou = dateExpire < new Date();
    if (tokenExpirou) {
      this.introspectToken().subscribe(value => {
        if (!value.active) {
          this.refreshToken().subscribe(model => {
            if (model) {
              this.stateManager.dispatch(new RefreshToken(model));
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
    const token = this.tokenModel.access_token;
    const postModel = new HttpParams({ fromObject: { token } });

    return this.http.post(`${url}/connect/introspect`, postModel, httpOptions)
      .pipe(
        catchError(this.handleError<any>('validarToken'))
      );
  }

  refreshToken(): Observable<TokenModel> {
    const refresh_token = this.tokenModel.refresh_token;
    const postModel = new HttpParams({
      fromObject: {
        grant_type: 'refresh_token',
        client_id: 'spa.client',
        refresh_token
      }
    });
    return this.http.post(`${url}/connect/token`, postModel, httpOptions)
      .pipe(
        catchError(this.handleError<any>('refreshToken'))
      );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (errorRequest: any): Observable<T> => {
      // Let the app keep running by returning an empty result.
      if (operation === 'refreshToken') {
        this.stateManager.dispatch(new Logout());
      }
      if (operation === 'obterToken') {
        const { error_description, error } = errorRequest.error;
        this.erros.adicionarErro( error_description === '' ? error : error_description ) ;
      }
      return of(result as T);
    };
  }
}

export class IntrospectModel {
  active = false;
}
