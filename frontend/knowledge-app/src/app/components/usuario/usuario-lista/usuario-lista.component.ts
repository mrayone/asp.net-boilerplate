import { Component, OnInit } from '@angular/core';
import { UsuarioService } from 'src/app/services/usuario.service';
import { DataTableService } from '../../shared/data-table/services/data-table-service';
import { DecimalPipe } from '@angular/common';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Router } from '@angular/router';

@Component({
  selector: 'app-usuario-lista',
  templateUrl: './usuario-lista.component.html',
  styleUrls: ['./usuario-lista.component.scss'],
  providers: [DataTableService, DecimalPipe]
})
export class UsuarioListaComponent implements OnInit {

  usuarios$: Observable<any[]>;
  constructor(private usuarioService: UsuarioService, private router: Router) {
    this.usuarios$ = this.usuarioService.getTodos().pipe(
      map((usuarios) => {
        usuarios.map((el) => {
          el.action = {
            view: this.router.createUrlTree(['usuarios/detalhes', el.id]).toString(),
            edit: this.router.createUrlTree(['usuarios/editar', el.id]).toString(),
            delete: this.router.createUrlTree(['usuarios/detalhes', el.id]).toString()
          };
        });
        return usuarios;
      })
    );
  }

  ngOnInit() {
  }
}

