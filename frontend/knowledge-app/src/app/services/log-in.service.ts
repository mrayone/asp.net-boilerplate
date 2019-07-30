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

  private url = "http://localhost:5001";
  private body: MyTokenModelTest;

  constructor(private http: HttpClient) {
    this.body = new MyTokenModelTest();
  }

  getTokenAcesso(): Observable<TokenModel> {
      return this.http.post(`${this.url}/connect/token`, this.body , httpOptions)
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
}

class MyTokenModelTest extends HttpParams {
  constructor() {
    super({
      fromObject: {
        grant_type: 'password',
        username: 'adminfake@mozej.com',
        password: '123456@IO',
        client_id: 'spa.client',
        scope: 'api offline_access',
      }
    });
  }
}

