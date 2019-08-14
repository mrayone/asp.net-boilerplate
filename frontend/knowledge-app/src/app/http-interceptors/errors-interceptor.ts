import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpResponse, HttpErrorResponse, HttpEvent } from '@angular/common/http';
import { Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { ErrosService } from '../services/erros.service';
import { InrequestService } from '../services/inrequest.service';
import { UsuarioAutenticadoService } from '../services/usuario-autenticado.service';


@Injectable()
export class ErrorsInterceptor implements HttpInterceptor {

  constructor(private erros: ErrosService, private inRequestService: InrequestService, private auth: UsuarioAutenticadoService,
     private router: Router) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    this.inRequestService.startRequest();
    return next.handle(req).pipe(
      tap(
        event => {
          if (event instanceof HttpResponse) {
            this.inRequestService.stopRequest();
          }
        }
      ),
      catchError(this.handleError<any>())
    );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (errorRequest: HttpErrorResponse): Observable<T> => {
      if (errorRequest.status === 403) {
        this.router.navigateByUrl(`/nao-autorizado`);
      }

      if (errorRequest.status === 401) {
        const tkModel = this.auth.getAuthorizationToken();
        if (this.auth.tokenExpirou(tkModel.access_token)) {
          this.auth.refreshToken(tkModel);
          this.router.navigate(['/dashboard']);
        }
      }

      if (errorRequest.status === 400) {
        const { error_description } = errorRequest.error;
        if (error_description) {
          this.erros.dispararErro(error_description);
        } else if (errorRequest.error instanceof Array) {
          this.erros.dispararRangeErros(errorRequest.error);
        } else {
          this.erros.dispararErro(errorRequest.error.error);
        }
      }

      this.inRequestService.stopRequest();
      return of(result as T);
    };
  }
}
