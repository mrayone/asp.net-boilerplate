import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppState } from '../state-manager/reducers';
import { Store } from '@ngrx/store';
import { LogInService } from '../services/log-in.service';
import { UsuarioAutenticadoService, UsuarioViewModel } from '../services/usuario-autenticado.service';
import { jwtParser } from '../Utils/jwtParser';
@Injectable()
export class CanActivateUser implements CanActivate {

  constructor(private store: Store<AppState>, private router: Router, private loginService: LogInService,
    private usuarioAutenticado: UsuarioAutenticadoService) { }

  canActivate(route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {

    if (!this.loginService.hasToken()) {
      this.router.navigate(['/login']);
      return false;
    }

    this.loginService.validateToken();

    return true;
  }
}
