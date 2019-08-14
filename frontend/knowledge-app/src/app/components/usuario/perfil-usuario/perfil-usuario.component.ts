import { Component, OnInit } from '@angular/core';
import { FormType } from '../../../Utils/formType/form-type.enum';
import { UsuarioAutenticadoService, UsuarioViewModel } from 'src/app/services/usuario-autenticado.service';
import { jwtParser } from 'src/app/Utils/jwtParser';
import { Usuario } from '../models/usuario';
import { UsuarioService } from 'src/app/services/usuario.service';
import { FormGroup } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { ErrosService } from 'src/app/services/erros.service';
import { take } from 'rxjs/operators';

@Component({
  selector: 'app-perfil-usuario',
  templateUrl: './perfil-usuario.component.html',
  styleUrls: ['./perfil-usuario.component.scss']
})
export class PerfilUsuarioComponent implements OnInit {

  formType: FormType = FormType.Put;
  usuario: Usuario;
  errosDeRequest: string[];
  constructor(private usuarioService: UsuarioService, private toastService: ToastrService) {
  }

  ngOnInit() {
    this.usuarioService.getUsuarioInfo().subscribe(usuario => {
      this.usuario = usuario;
    });
  }

  putUsuarioPerfil(form: FormGroup) {
    if (form.dirty && form.valid) {
      const usuario: Usuario = Object.assign({}, new Usuario(), form.value);
      usuario.dataDeNascimento =
        `${form.value.dataDeNascimento.year}-${form.value.dataDeNascimento.month}-${form.value.dataDeNascimento.day}`;

      this.usuarioService.putUsuarioPerfil(usuario).subscribe(response => {
          this.toastService.success('Operação realizada com sucesso!');
      });
    }
  }
}
