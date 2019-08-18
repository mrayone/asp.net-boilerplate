import { Component, OnInit, Input } from '@angular/core';

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

  constructor() {
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

}
