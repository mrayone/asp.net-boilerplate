import { Component, OnInit } from '@angular/core';
import { Store, select } from '@ngrx/store';
import { AppState } from './store/reducers';
import { ObterTokenModel } from './store/selectors/app.selector';
import { Observable, interval } from 'rxjs';
import { ReaverToken } from './store/actions/app.actions';
import { TokenModel } from './services/config/models/models';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent implements OnInit {
  autenticado: boolean;
  tokenModel$: Observable<TokenModel>;
  constructor(private store: Store<AppState>) {
    this.store.dispatch(new ReaverToken());
    this.tokenModel$ = this.store.pipe(select(ObterTokenModel));
  }

  ngOnInit(): void {
    this.validarToken();
  }

  validarToken(): void {
    this.tokenModel$.subscribe(val => {
      this.autenticado = val !== null;
    });
  }
}
