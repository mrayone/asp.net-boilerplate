import { Component, OnInit } from '@angular/core';
import { FormType } from '../formulario/formType/form-type.enum';
import { UsuarioAutenticadoService, UsuarioViewModel } from 'src/app/services/usuario-autenticado.service';
import { jwtParser } from 'src/app/Utils/jwtParser';
import { Usuario } from '../models/usuario';
import { UsuarioService } from 'src/app/services/usuario.service';

@Component({
  selector: 'app-perfil-usuario',
  templateUrl: './perfil-usuario.component.html',
  styleUrls: ['./perfil-usuario.component.scss']
})
export class PerfilUsuarioComponent implements OnInit {

  formType: FormType = FormType.Put;
  usuario: Usuario;
  constructor( private usuarioService: UsuarioService ) {

  }

  ngOnInit() {
    this.usuarioService.getUsuarioInfo().subscribe(usuario => {
      this.usuario = usuario;
    });
   }
}
