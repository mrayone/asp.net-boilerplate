import { Component, OnInit } from '@angular/core';
import { Store, select } from '@ngrx/store';
import { AppState } from './state-manager/reducers';
import { TokenModel } from './services/log-in.service';
import { ObterTokenModel } from './state-manager/selectors/token.selector';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent implements OnInit {
  autenticado: boolean;

  constructor(private store: Store<AppState>) {}

  ngOnInit(): void {
    this.store.pipe(select(ObterTokenModel))
    .subscribe(token => {
      this.autenticado = !!token;
    });
  }
}
