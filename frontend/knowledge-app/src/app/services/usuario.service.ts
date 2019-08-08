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

  getPorId(id: string): Observable<Usuario[]> {
    const options = {
       headers: new HttpHeaders({'Content-Type': 'application/json'}),
       params: new HttpParams().set('id', id)
    };
    return this.http.get(`${url}/api/v1/usuarios/obter-todos`, options)
      .pipe(
        catchError(this.handleError<any>('getAllUsuarios'))
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
