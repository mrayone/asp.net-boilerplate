import { Injectable } from '@angular/core';
import { url, httpOptions } from './config/config';
import { HttpClient, HttpResponse, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Usuario } from '../components/usuario/models/usuario';
import { Perfil } from '../components/perfil/models/perfil';
import { ErrosService } from './erros.service';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  constructor(private http: HttpClient, private errosService: ErrosService) { }


  post(usuario: Usuario): Observable<HttpResponse<any>> {
    return this.http.post(`${url}/api/v1/usuarios`, usuario, httpOptions)
      .pipe(
        catchError(this.handleError<any>('postUsuario'))
      );
  }

  put(usuario: Usuario): Observable<HttpResponse<any>> {
    return this.http.put(`${url}/api/v1/usuarios`, usuario, httpOptions)
      .pipe(
        catchError(this.handleError<any>('putUsuario'))
      );
  }

  delete(uid: string) {
    return this.http.delete(`${url}/api/v1/usuarios/${uid}`, httpOptions)
      .pipe(
        catchError(this.handleError<any>('deleteUsuario'))
      );
  }

  putUsuarioPerfil(usuario: Usuario): Observable<HttpResponse<any>> {
    return this.http.put(`${url}/api/v1/usuarios/atualizar-perfil`, usuario, httpOptions)
      .pipe(
        catchError(this.handleError<any>('putAtualizarPerfil'))
      );
  }

  getTodos(): Observable<Usuario[]> {
    return this.http.get(`${url}/api/v1/usuarios/obter-todos`, httpOptions)
      .pipe(
        catchError(this.handleError<any>('getTodosUsuarios'))
      );
  }

  getPorId(uid: string): Observable<Usuario> {
    return this.http.get(`${url}/api/v1/usuarios/${uid}`, httpOptions)
      .pipe(
        catchError(this.handleError<any>('getUsuarioPorId'))
      );
  }

  getUsuarioInfo(): Observable<Usuario> {
    return this.http.get(`${url}/api/v1/usuarios/info`, httpOptions)
      .pipe(
        catchError(this.handleError<any>('getUsuarioInfo'))
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
