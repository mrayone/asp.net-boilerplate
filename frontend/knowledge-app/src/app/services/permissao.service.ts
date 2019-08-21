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

  constructor(private http: HttpClient) { }

  post(permissao: Permissao): Observable<HttpResponse<any>> {
    return this.http.post<HttpResponse<any>>(`${url}/api/v1/permissoes`, permissao, httpOptions);
  }

  put(permissao: Permissao): Observable<HttpResponse<any>> {
    return this.http.put<HttpResponse<any>>(`${url}/api/v1/permissoes`, permissao, httpOptions);
  }

  delete(uid: string) {
    return this.http.delete(`${url}/api/v1/permissoes/${uid}`, httpOptions);
  }

  getTodas(): Observable<Permissao[]> {
    return this.http.get<Permissao[]>(`${url}/api/v1/permissoes/obter-todas`, httpOptions);
  }

  getPorId(uid: string): Observable<Permissao> {
    return this.http.get<Permissao>(`${url}/api/v1/permissoes/${uid}`, httpOptions);
  }
}
