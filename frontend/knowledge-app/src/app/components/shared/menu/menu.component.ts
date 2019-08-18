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

  ngOnInit() {
  }

}
