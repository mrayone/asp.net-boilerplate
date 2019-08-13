import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpResponse, HttpErrorResponse, HttpEvent } from '@angular/common/http';
import { UsuarioAutenticadoService } from '../services/usuario-autenticado.service';
import { Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { eventNames } from 'cluster';
import { tap, catchError } from 'rxjs/operators';


@Injectable()
export class ErrorsInterceptor implements HttpInterceptor {

  constructor(private auth: UsuarioAutenticadoService, private router: Router) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(
      catchError(this.handleError<any>())
    );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (errorRequest: HttpErrorResponse): Observable<T> => {
      if (errorRequest.status === 403) {
        this.router.navigateByUrl(`/nao-autorizado`);
      }

      if (errorRequest.status === 401) {
        this.router.navigateByUrl(`/login`);
      }
      return of(result as T);
    };
  }
}
