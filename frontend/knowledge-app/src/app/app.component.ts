import { Component, OnInit } from '@angular/core';
import { Store, select } from '@ngrx/store';
import { AppState } from './state-manager/reducers';
import { ObterTokenModel } from './state-manager/selectors/token.selector';
import { Observable, interval } from 'rxjs';
import { ReaverToken } from './state-manager/actions/autorizacao/autorizacao.actions';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent implements OnInit {
  autenticado: boolean;

  constructor(private store: Store<AppState>) {
    this.store.dispatch(new ReaverToken());
  }

  ngOnInit(): void {
    this.validarToken();
  }

  validarToken(): void {
    this.store.pipe(select(ObterTokenModel))
    .subscribe(token => {
      this.autenticado = !!token;
    });
  }
}
