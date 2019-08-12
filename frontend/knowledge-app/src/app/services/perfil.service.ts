import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Perfil } from '../components/perfil/models/perfil';
import { url, httpOptions } from './config/config';
import { catchError } from 'rxjs/operators';
import { ErrosService } from './erros.service';
import { AtribuicaoDTO } from '../components/perfil/models/atribuicaoDTO';

@Injectable({
  providedIn: 'root'
})
export class PerfilService {

  constructor(private http: HttpClient, private errosService: ErrosService) { }

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

  public putAtribuirPermissoes(perfilId: string, atribuicoes: AtribuicaoDTO[] ): Observable<HttpResponse<any>> {
    const objeto = {
      perfilId,
      atribuicoes
    };
    return this.http.put(`${url}/api/v1/perfis/atribuir-permissoes`, objeto, httpOptions)
    .pipe(
      catchError(this.handleError<any>('putAtribuirPermissoes'))
    );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (errorRequest: any): Observable<T> => {
      const { error_description, error } = errorRequest.error;
      this.errosService.adicionarErro( error_description === '' ? error : error_description ) ;
      console.error(error);
      return of(result as T);

    };
  }
}
