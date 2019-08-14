import { Component, OnInit } from '@angular/core';
import { Router, ActivationStart, ActivatedRoute } from '@angular/router';
import { map, filter } from 'rxjs/operators';
import { Store } from '@ngrx/store';
import { AppState } from 'src/app/state-manager/reducers';
import { Logout } from 'src/app/state-manager/actions/autorizacao.actions';
import { UsuarioViewModel, UsuarioAutenticadoService } from 'src/app/services/usuario-autenticado.service';
import { jwtParser } from 'src/app/Utils/jwtParser';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  public titulo =  'Knowledg.IO';
  usuario: UsuarioViewModel;
  constructor(private router: Router, private store: Store<AppState>, private usuarioService: UsuarioAutenticadoService) {
   }

  ngOnInit() {
    this.router.events.pipe( filter(event => event instanceof ActivationStart) )
    .subscribe(event => {
      const { snapshot } = event as ActivatedRoute;
      this.titulo =  snapshot.data.title;
     });

    const tokenModel = this.usuarioService.getAuthorizationToken();
    this.usuario = jwtParser(tokenModel.access_token) as UsuarioViewModel;
  }
  onLogout() {
    this.store.dispatch(new Logout());
    this.router.navigate(['/login']);
  }
}
