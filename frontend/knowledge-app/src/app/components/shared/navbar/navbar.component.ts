import { Component, OnInit } from '@angular/core';
import { Router, ActivationStart, ActivatedRoute } from '@angular/router';
import { map, filter } from 'rxjs/operators';
import { Store } from '@ngrx/store';
import { AppState } from 'src/app/state-manager/reducers';
import { Logout } from 'src/app/state-manager/actions/autorizacao/autorizacao.actions';
import { UsuarioViewModel, UsuarioLogadoService } from 'src/app/services/usuario-logado.service';
import { jwtParser } from 'src/app/Utils/jwtParser';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  public titulo =  'Knowledg.IO';
  usuario: UsuarioViewModel;
  constructor(private router: Router, private store: Store<AppState>, private usuarioService: UsuarioLogadoService) {
   }

  ngOnInit() {
    this.router.events.pipe( filter(event => event instanceof ActivationStart) )
    .subscribe(event => {
      const { snapshot } = event as ActivatedRoute;
      this.titulo =  snapshot.data.title;
     });

    this.usuarioService.tokenModel$.subscribe(model => {
      if (model) {
        this.usuario = jwtParser(model.access_token) as UsuarioViewModel;
      }
    });
  }
  onLogout() {
    this.store.dispatch(new Logout());
    this.router.navigate(['/login']);
  }
}
