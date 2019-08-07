import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler } from '@angular/common/http';
import { UsuarioAutenticadoService } from '../services/usuario-autenticado.service';


@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor(private auth: UsuarioAutenticadoService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler) {
      const bearerToken = this.auth.getAuthorizationToken();

      const authReq = req.clone();

      if (!authReq.headers.has('Authorization')) {
        authReq.headers.append('Authorization', `Bearer ${bearerToken}`);
      }

      return next.handle(authReq);
  }

}
