import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { Logout, RefreshToken } from '../store/actions/app.actions';
import { AppState } from '../store/reducers';
import { LOGIN_KEY } from '../store/reducers/app.reducer';
import { ObterTokenModel } from '../store/selectors/app.selector';
import { jwtParser } from '../Utils/jwtParser';
import { url } from './config/config';
import { GrantAcessModel, TokenModel } from './config/models/models';
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
    return this.http.post<TokenModel>(`${url}/connect/token`, grantAcess, httpOptions);
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
              this.stateManager.dispatch(new RefreshToken({ auth: model}));
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

    return this.http.post<IntrospectModel>(`${url}/connect/introspect`, postModel, httpOptions);
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
    return this.http.post<TokenModel>(`${url}/connect/token`, postModel, httpOptions);
  }
}

export class IntrospectModel {
  active = false;
}
