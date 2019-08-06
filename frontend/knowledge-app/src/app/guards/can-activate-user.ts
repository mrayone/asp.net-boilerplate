import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { Observable, interval } from 'rxjs';
import { ObterTokenModel } from '../state-manager/selectors/token.selector';
import { AppState } from '../state-manager/reducers';
import { Store, select } from '@ngrx/store';
import { ReaverToken } from '../state-manager/actions/autorizacao/autorizacao.actions';
import { LogInService } from '../services/log-in.service';
@Injectable()
export class CanActivateUser implements CanActivate {

  constructor(private store: Store<AppState>, private router: Router, private loginService: LogInService) { }

   canActivate(route: ActivatedRouteSnapshot,
              state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {

      // TODO: implementar aqui
      if (!this.loginService.hasToken()) {
        this.router.navigate(['/login']);
        return false;
      } else  {
        this.loginService.validarToken();
        return true;
      }
  }

}
