import { Injectable } from '@angular/core';
import { url, httpOptions } from './config/config';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Usuario } from '../components/usuario/models/usuario';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  constructor(private http: HttpClient) { }


  post(usuario: Usuario): Observable<HttpResponse<any>> {
    return this.http.post<HttpResponse<any>>(`${url}/api/v1/usuarios`, usuario, httpOptions);
  }

  put(usuario: Usuario): Observable<HttpResponse<any>> {
    return this.http.put<HttpResponse<any>>(`${url}/api/v1/usuarios`, usuario, httpOptions);
  }

  delete(uid: string) {
    return this.http.delete(`${url}/api/v1/usuarios/${uid}`, httpOptions);
  }

  putUsuarioPerfil(usuario: Usuario): Observable<HttpResponse<any>> {
    return this.http.put<HttpResponse<any>>(`${url}/api/v1/usuarios/atualizar-perfil`, usuario, httpOptions);
  }

  getTodos(): Observable<Usuario[]> {
    return this.http.get<Usuario[]>(`${url}/api/v1/usuarios/obter-todos`, httpOptions);
  }

  getPorId(uid: string): Observable<Usuario> {
    return this.http.get<Usuario>(`${url}/api/v1/usuarios/${uid}`, httpOptions);
  }

  postSolicitarNovaSenha(email: string): Observable<HttpResponse<any>> {
    const obj = {
      email
    };
    return this.http.post<HttpResponse<any>>(`${url}/api/v1/usuarios/esqueci-a-senha`, obj, httpOptions);
  }

  postRedefinirSenha(email: string, senha: string, confirmaSenha: string, token: string): Observable<HttpResponse<any>> {
    const obj = {
      email,
      senha,
      confirmaSenha
    };
    return this.http.put<HttpResponse<any>>(`${url}/api/v1/usuarios/redefinir-senha?token=${token}`, obj, httpOptions);
  }

  getUsuarioInfo(): Observable<Usuario> {
    return this.http.get<Usuario>(`${url}/api/v1/usuarios/info`, httpOptions);
  }
}
