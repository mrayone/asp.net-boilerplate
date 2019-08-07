import { Injectable } from '@angular/core';
import { url, httpOptions } from './config/config';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Usuario } from '../components/usuario/models/usuario';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  constructor(private http: HttpClient) { }


  post(usuario: Usuario) {
    return this.http.post(`${url}/usuarios`, usuario, httpOptions )
    .pipe(
      catchError(this.handleError<any>('postUsuario'))
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
