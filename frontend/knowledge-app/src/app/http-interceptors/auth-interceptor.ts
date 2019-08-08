import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpHeaders } from '@angular/common/http';
import { UsuarioAutenticadoService } from '../services/usuario-autenticado.service';


@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor(private auth: UsuarioAutenticadoService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler) {
      const bearerToken = this.auth.getAuthorizationToken();

      if (!req.headers.has('Authorization')) {
        const authReq = req.clone({
          headers: new HttpHeaders({
            Authorization: `Bearer ${bearerToken}`
          })
        });

        return next.handle(authReq);
      }

      return next.handle(req.clone());
  }

}
