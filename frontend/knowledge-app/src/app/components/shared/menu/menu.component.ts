import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { AppState } from 'src/app/store/reducers';
import { Logout } from 'src/app/store/actions/app.actions';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {

  isCollapseUsuario = false;
  isCollapsePermissao = false;
  isCollapsePerfil = false;
  @Input() showMenu = false;

  constructor(private router: Router, private store: Store<AppState>) {
  }

  collapseAction(item: string) {

    switch (item) {
      case 'subMenuUsuario':
        this.isCollapseUsuario = !this.isCollapseUsuario;
        this.isCollapsePermissao = false;
        this.isCollapsePerfil = false;
        break;
      case 'subMenuPerfil':
        this.isCollapseUsuario = false;
        this.isCollapsePermissao = false;
        this.isCollapsePerfil = !this.isCollapsePerfil;
        break;
      case 'subMenuPermissao':
        this.isCollapsePermissao = !this.isCollapsePermissao ;
        this.isCollapseUsuario = false;
        this.isCollapsePerfil = false;
        break;
    }
  }

  ngOnInit() {
  }

  logout() {
    this.store.dispatch(new Logout());
    this.router.navigate(['/login']);
  }
}
