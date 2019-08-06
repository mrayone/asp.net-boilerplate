import { Component, OnInit } from '@angular/core';
import { FormType } from '../usuario/formulario/formType/form-type.enum';
import { UsuarioLogadoService, UsuarioViewModel } from 'src/app/services/usuario-logado.service';
import { jwtParser } from 'src/app/Utils/jwtParser';

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.scss']
})
export class PerfilComponent implements OnInit {

  formType: FormType = FormType.Put;
  usuario: UsuarioViewModel;
  constructor( private usuarioLogado: UsuarioLogadoService ) { }

  ngOnInit() {
    this.usuarioLogado.tokenModel$.subscribe(model => {
      this.usuario = jwtParser(model.access_token) as UsuarioViewModel;
    });
  }
}
