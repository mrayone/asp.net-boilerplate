import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { logging } from 'protractor';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { catchError } from 'rxjs/operators';

const httpOptions = {
  headers: new HttpHeaders({'Content-Type': 'application/x-www-form-urlencoded'})
};

@Injectable({
  providedIn: 'root'
})
export class LogInService {

  private url = 'http://localhost:5001';

  constructor(private http: HttpClient) {

  }

  getTokenAcesso( grantAcess: GrantAcessModel): Observable<TokenModel> {
      return this.http.post(`${this.url}/connect/token`, grantAcess , httpOptions)
      .pipe(
        catchError(this.handleError<any>('obterToken'))
      );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: {}): Observable<T> => {
      // Let the app keep running by returning an empty result.
      console.error(error);
      return of(result as T);
    };
  }
}

export class TokenModel {
  access_token: string;
  expires_in: number;
  token_type: string;
  refresh_token: string;
  scope: string;

  constructor() {}
}

export class GrantAcessModel extends HttpParams {
  constructor( username: string, password: string, grant_type: string = 'password',
               client_id: string = 'spa.client', scope: string = 'api offline_access' ) {
    super({
      fromObject: {
        grant_type,
        username,
        password,
        client_id,
        scope,
      }
    });
  }
}

