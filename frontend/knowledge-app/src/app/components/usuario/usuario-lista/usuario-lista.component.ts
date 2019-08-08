import { Component, OnInit } from '@angular/core';
import { UsuarioService } from 'src/app/services/usuario.service';
import { Usuario } from '../models/usuario';

@Component({
  selector: 'app-usuario-lista',
  templateUrl: './usuario-lista.component.html',
  styleUrls: ['./usuario-lista.component.scss']
})
export class UsuarioListaComponent implements OnInit {

  private getUsuarios: Usuario[];
  page = 1;
  pageSize = 4;
  collectionSize = 0;
  constructor(private usuarioService: UsuarioService) {
    this.getUsuarios = new Array<Usuario>();
  }

  ngOnInit() {
    this.usuarioService.getTodos().subscribe(usuarios => {
      this.getUsuarios = usuarios;
      this.collectionSize = this.getUsuarios.length;
    });
  }
  get usuarios(): Usuario[] {

    return this.getUsuarios.map((usuario, i) => ({ id: i + 1, ...usuario }))
      .slice((this.page - 1) * this.pageSize, (this.page - 1) * this.pageSize + this.pageSize)
  }
}
