import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Perfil } from '../components/perfil/models/perfil';
import { url, httpOptions } from './config/config';
import { catchError, retry } from 'rxjs/operators';
import { ErrosService } from './erros.service';
import { AtribuicaoDTO } from '../components/perfil/models/atribuicaoDTO';

@Injectable({
  providedIn: 'root'
})
export class PerfilService {

  constructor(private http: HttpClient) { }

  post(perfil: Perfil): Observable<HttpResponse<any>> {
    return this.http.post<HttpResponse<any>>(`${url}/api/v1/perfis`, perfil, httpOptions);
  }

  put(perfil: Perfil): Observable<HttpResponse<any>> {
    return this.http.put<HttpResponse<any>>(`${url}/api/v1/perfis`, perfil, httpOptions);
  }

  delete(uid: string) {
    return this.http.delete(`${url}/api/v1/perfis/${uid}`, httpOptions);
  }

  getPorId(uid: string): Observable<Perfil> {
    return this.http.get<Perfil>(`${url}/api/v1/perfis/${uid}`, httpOptions);
  }

  public getTodos(): Observable<Perfil[]> {
    return this.http.get<Perfil[]>(`${url}/api/v1/perfis/obter-todos`);
  }

  public putAtribuirPermissoes(perfilId: string, atribuicoes: AtribuicaoDTO[] ): Observable<HttpResponse<any>> {
    const objeto = {
      perfilId,
      atribuicoes
    };
    return this.http.put<HttpResponse<any>>(`${url}/api/v1/perfis/atribuir-permissoes`, objeto, httpOptions);
  }
}
