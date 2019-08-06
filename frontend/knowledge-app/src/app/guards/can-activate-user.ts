import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TokenModel } from '../services/log-in.service';
import { ObterTokenModel } from '../state-manager/selectors/token.selector';
import { AppState } from '../state-manager/reducers';
import { Store, select } from '@ngrx/store';
@Injectable()
export class CanActivateUser implements CanActivate {

  constructor(private store: Store<AppState>, private router: Router) { }

  canActivate(route: ActivatedRouteSnapshot,
              state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
      let tokenModel: TokenModel = null;
      // TODO: implementar aqui
      this.store.pipe(select(ObterTokenModel))
      .subscribe(token => tokenModel = token);

      if (!tokenModel) {
        this.router.navigate(['/login']);
        return false;
      }

      return true;
  }
}
