import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { Observable, interval } from 'rxjs';
import { ObterTokenModel } from '../state-manager/selectors/token.selector';
import { AppState } from '../state-manager/reducers';
import { Store, select } from '@ngrx/store';
import { ReaverToken } from '../state-manager/actions/autorizacao/autorizacao.actions';
import { LogInService } from '../services/log-in.service';
import { UsuarioAutenticadoService, UsuarioViewModel } from '../services/usuario-autenticado.service';
import { jwtParser } from '../Utils/jwtParser';
@Injectable()
export class CanActivateUser implements CanActivate {

  constructor(private store: Store<AppState>, private router: Router, private loginService: LogInService,
    private usuarioAutenticado: UsuarioAutenticadoService) { }

   canActivate(route: ActivatedRouteSnapshot,
              state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {

      // TODO: implementar aqui
      if (!this.loginService.hasToken()) {
        this.router.navigate(['/login']);
        return false;
      }

      this.loginService.validateToken();
      return true;

      // if (!this.checarClaims()) {
      //     this.router.navigate(['/nao-autorizado']);
      //     return false;
      // }
  }

  checarClaims(): boolean {
    let contemClaim = true;
    let usuarioModel: UsuarioViewModel;

    this.usuarioAutenticado.tokenModel$.subscribe(tkModel => {
      usuarioModel = jwtParser(tkModel.access_token) as UsuarioViewModel;

      const claim = usuarioModel.permissions.find((val, i) => {
          return this.checarPermissaoRota(val);
      });

      contemClaim = !!claim;
    });

    return contemClaim;
  }

  checarPermissaoRota(valor: string): boolean {
    switch (this.router.url) {
      case '/usuarios/adicionar':
        return valor === 'Criar Usuário';
      case '/usuarios':
        return valor === 'Visualizar Usuários';
      default:
        return true;
    }
  }
}
