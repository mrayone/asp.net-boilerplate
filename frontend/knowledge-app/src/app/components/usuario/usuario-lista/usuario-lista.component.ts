import { Component, OnInit } from '@angular/core';
import { UsuarioService } from 'src/app/services/usuario.service';
import { Usuario } from '../models/usuario';

@Component({
  selector: 'app-usuario-lista',
  templateUrl: './usuario-lista.component.html',
  styleUrls: ['./usuario-lista.component.scss']
})
export class UsuarioListaComponent implements OnInit {

  private usuariosServe: Usuario[] = [];
  page = 1;
  pageSize = 4;
  collectionSize = this.usuariosServe.length;
  constructor(private usuarioService: UsuarioService) {
    this.usuarioService.getTodos().subscribe(usuarios => {
      this.usuariosServe = usuarios;
      this.collectionSize = this.usuariosServe.length;
    });
  }

  ngOnInit() {

  }

  get usuarios(): Usuario[] {
    return this.usuariosServe
      .map((usuario, i) => ({ id: i + 1, ...usuario }))
      .slice((this.page - 1) * this.pageSize, (this.page - 1) * this.pageSize + this.pageSize);
  }

}
