import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpHeaders } from '@angular/common/http';
import { UsuarioAutenticadoService } from '../services/usuario-autenticado.service';
import { Router } from '@angular/router';


@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor(private auth: UsuarioAutenticadoService, private router: Router) { }

  intercept(req: HttpRequest<any>, next: HttpHandler) {
    if (this.router.url === '/login') { return next.handle(req.clone()); }

    const bearerToken = this.auth.getAuthorizationToken().access_token;

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
