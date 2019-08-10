import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Perfil } from '../components/perfil/models/perfil';
import { url, httpOptions } from './config/config';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class PerfilService {

  constructor(private http: HttpClient) { }

  post(perfil: Perfil): Observable<HttpResponse<any>> {
    return this.http.post(`${url}/api/v1/perfis`, perfil, httpOptions)
      .pipe(
        catchError(this.handleError<any>('postPerfil'))
      );
  }

  put(perfil: Perfil): Observable<HttpResponse<any>> {
    return this.http.put(`${url}/api/v1/perfis`, perfil, httpOptions)
      .pipe(
        catchError(this.handleError<any>('putPerfil'))
      );
  }

  delete(uid: string) {
    return this.http.delete(`${url}/api/v1/perfis/${uid}`, httpOptions)
      .pipe(
        catchError(this.handleError<any>('deletePerfil'))
      );
  }

  getPorId(uid: string): Observable<Perfil> {
    return this.http.get(`${url}/api/v1/perfis/${uid}`, httpOptions)
      .pipe(
        catchError(this.handleError<any>('getPerfilPorId'))
      );
  }

  public getTodos(): Observable<Perfil[]> {
    return this.http.get(`${url}/api/v1/perfis/obter-todos`)
    .pipe(
      catchError(this.handleError<any>('getTodosOsPerfis'))
    );
  }

  //TODO: Atribuir Permissões

  //TODO: RevogarPermissões

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: {}): Observable<T> => {
      // Let the app keep running by returning an empty result.
      console.error(error);
      return of(result as T);
    };
  }
}
