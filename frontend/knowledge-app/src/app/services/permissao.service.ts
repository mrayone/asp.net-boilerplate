import { Injectable } from '@angular/core';
import { ErrosService } from './erros.service';
import { catchError } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import { url, httpOptions } from './config/config';
import { HttpResponse, HttpClient } from '@angular/common/http';
import { Permissao } from '../components/permissao/Models/permissao';

@Injectable({
  providedIn: 'root'
})
export class PermissaoService {

  constructor(private http: HttpClient, private errosService: ErrosService) { }

  post(permissao: Permissao): Observable<HttpResponse<any>> {
    return this.http.post(`${url}/api/v1/permissoes`, permissao, httpOptions)
      .pipe(
        catchError(this.handleError<any>('postPermissao'))
      );
  }

  put(permissao: Permissao): Observable<HttpResponse<any>> {
    return this.http.put(`${url}/api/v1/permissoes`, permissao, httpOptions)
      .pipe(
        catchError(this.handleError<any>('putPermissao'))
      );
  }

  delete(uid: string) {
    return this.http.delete(`${url}/api/v1/permissoes/${uid}`, httpOptions)
      .pipe(
        catchError(this.handleError<any>('deletePermissao'))
      );
  }

  getTodas(): Observable<Permissao[]> {
    return this.http.get(`${url}/api/v1/permissoes/obter-todas`, httpOptions)
      .pipe(
        catchError(this.handleError<any>('getTodasPermissoes'))
      );
  }

  getPorId(uid: string): Observable<Permissao> {
    return this.http.get(`${url}/api/v1/permissoes/${uid}`, httpOptions)
      .pipe(
        catchError(this.handleError<any>('getUsuarioPorId'))
      );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: {}): Observable<T> => {
      // Let the app keep running by returning an empty result.
      this.errosService.adicionarRange(error['error']);
      return of(result as T);
    };
  }
}
