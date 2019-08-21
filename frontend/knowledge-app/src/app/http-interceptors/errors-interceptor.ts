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

      switch (errorRequest.status) {
        case 400:
          this.error400(errorRequest);
          break;
        case 401:
          this.error401();
          break;
        case 403:
          this.error403();
          break;
        case 404:
          this.error404();
          break;
      }

      this.inRequestService.stopRequest();
      return of(result as T);
    };
  }

  error403() {
    this.router.navigateByUrl(`/nao-autorizado`);
  }
  error401() {
    const tkModel = this.auth.getAuthorizationToken();
    if (this.auth.tokenExpirou(tkModel.access_token)) {
      this.auth.refreshToken(tkModel);
      this.router.navigate(['/dashboard']);
    }
  }

  error400(errorRequest: HttpErrorResponse) {
    const { error_description } = errorRequest.error;
    if (error_description) {
      this.erros.dispararErro(error_description);
    } else if (errorRequest.error instanceof Array) {
      this.erros.dispararRangeErros(errorRequest.error);
    } else {
      this.erros.dispararErro(errorRequest.error.error);
    }
  }

  error404() {
    this.router.navigateByUrl(`/nao-encontrou`);
  }
}
