import { Component, OnInit } from '@angular/core';
import { Usuario } from '../models/usuario';
import { UsuarioService } from 'src/app/services/usuario.service';
import { Router, Route, ActivatedRoute, ParamMap } from '@angular/router';
import { switchMap } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-usuario-detalhes',
  templateUrl: './usuario-detalhes.component.html',
  styleUrls: ['./usuario-detalhes.component.scss']
})
export class UsuarioDetalhesComponent implements OnInit {

  usuario: Usuario;
  constructor(private usuarioService: UsuarioService, private route: ActivatedRoute, private router: Router) {
    //this.usuario = new Usuario();
   }

  ngOnInit() {
   this.route.paramMap.pipe(
      switchMap( (params: ParamMap) =>
       this.usuarioService.getPorId(params.get('id'))
      )
    ).subscribe(map => {
      this.usuario = map;
    });
  }

}
