import { Component, OnInit } from '@angular/core';
import { Perfil } from '../models/perfil';
import { PerfilService } from 'src/app/services/perfil.service';

@Component({
  selector: 'app-listar-perfis',
  templateUrl: './listar-perfis.component.html',
  styleUrls: ['./listar-perfis.component.scss']
})
export class ListarPerfisComponent implements OnInit {

  private getPerfis: Perfil[];
  page = 1;
  pageSize = 4;
  collectionSize = 0;
  constructor(private perfilSerivce: PerfilService) {
    this.getPerfis = new Array<Perfil>();
  }

  ngOnInit() {
    this.perfilSerivce.getTodos().subscribe(perfis => {
      this.getPerfis = perfis;
      this.collectionSize = this.getPerfis.length;
    });
  }


  get perfis(): Perfil[] {
    return this.getPerfis.map((perfil, i) => ({ id: i + 1, ...perfil }))
      .slice((this.page - 1) * this.pageSize, (this.page - 1) * this.pageSize + this.pageSize);
  }
}
