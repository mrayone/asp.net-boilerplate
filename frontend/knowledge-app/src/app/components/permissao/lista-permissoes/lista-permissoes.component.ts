import { Component, OnInit } from '@angular/core';
import { Permissao } from '../Models/permissao';
import { PermissaoService } from 'src/app/services/permissao.service';

@Component({
  selector: 'app-lista-permissoes',
  templateUrl: './lista-permissoes.component.html',
  styleUrls: ['./lista-permissoes.component.scss']
})
export class ListaPermissoesComponent implements OnInit {

  private getPermissoes: Permissao[];
  page = 1;
  pageSize = 4;
  collectionSize = 0;
  constructor(private permissaoService: PermissaoService) {
    this.getPermissoes = new Array<Permissao>();
  }

  ngOnInit() {
    this.permissaoService.getTodas().subscribe(permissoes => {
      this.getPermissoes = permissoes;
      this.collectionSize = this.getPermissoes.length;
    });
  }
  get permissoes(): Permissao[] {

    return this.getPermissoes.map((permissao, i) => ({ id: i + 1, ...permissao }))
      .slice((this.page - 1) * this.pageSize, (this.page - 1) * this.pageSize + this.pageSize);
  }
}
