import { Component, OnInit } from '@angular/core';
import { TituloService } from 'src/app/services/titulo.service';

@Component({
  selector: 'app-adicionar-usuario',
  templateUrl: './adicionar-usuario.component.html',
  styleUrls: ['./adicionar-usuario.component.scss']
})
export class AdicionarUsuarioComponent implements OnInit {
  titulo: string;

  constructor(private tituloService: TituloService) { }

  ngOnInit() {
    this.titulo = this.tituloService.titulo;
  }

}
