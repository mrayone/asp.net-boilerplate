import { Component, OnInit } from '@angular/core';
import { Permissao } from '../Models/permissao';
import { PermissaoService } from 'src/app/services/permissao.service';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Router } from '@angular/router';

@Component({
  selector: 'app-lista-permissoes',
  templateUrl: './lista-permissoes.component.html',
  styleUrls: ['./lista-permissoes.component.scss']
})
export class ListaPermissoesComponent implements OnInit {

  permissoes$: Observable<Permissao[]>;
  constructor(private permissaoService: PermissaoService, private router: Router) {
  }

  ngOnInit() {
    this.permissoes$ = this.permissaoService.getTodas()
    .pipe(
      map(permissoes => {
        permissoes.map((el) => {
          el.action = {
            view: this.router.createUrlTree(['permissoes/detalhes', el.id]).toString(),
            edit: this.router.createUrlTree(['permissoes/editar', el.id]).toString(),
            delete: this.router.createUrlTree(['permissoes/detalhes', el.id]).toString()
          };
        });
        return permissoes;
      })
    );
  }
}
