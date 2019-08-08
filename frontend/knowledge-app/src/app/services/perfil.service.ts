import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Perfil } from '../components/perfil/models/perfil';
import { url, httpOptions } from './config/config';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class PerfilService {

  constructor(private http: HttpClient) { }

  public getPerfis(): Observable<Perfil[]> {
    return this.http.get(`${url}/api/v1/perfis/obter-todos`)
    .pipe(
      catchError(this.handleError<any>('getPerfis'))
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
