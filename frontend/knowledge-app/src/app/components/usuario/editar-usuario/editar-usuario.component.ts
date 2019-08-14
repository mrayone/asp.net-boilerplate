import { Component, OnInit } from '@angular/core';
import { Usuario } from '../models/usuario';
import { UsuarioService } from 'src/app/services/usuario.service';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { switchMap, take } from 'rxjs/operators';
import { FormType } from '../../../Utils/formType/form-type.enum';
import { FormGroup } from '@angular/forms';
import { ErrosService } from 'src/app/services/erros.service';
import { ToastrService } from 'ngx-toastr';
import { Perfil } from '../../perfil/models/perfil';
import { PerfilService } from 'src/app/services/perfil.service';
import { AppState } from 'src/app/store/reducers';
import { Store, select } from '@ngrx/store';
import { InRequest } from 'src/app/store/selectors/app.selector';

@Component({
  selector: 'app-editar-usuario',
  templateUrl: './editar-usuario.component.html',
  styleUrls: ['./editar-usuario.component.scss']
})
export class EditarUsuarioComponent implements OnInit {

  formType: FormType = FormType.Put;
  usuario: Usuario;
  errosDeRequest: string[];
  perfis: Perfil[];
  InRequest = false;
  constructor(private usuarioService: UsuarioService, private toastService: ToastrService, private route: ActivatedRoute,
    private router: Router, private perfilService: PerfilService) {
  }

  ngOnInit() {
    this.route.paramMap.pipe(
      switchMap((params: ParamMap) =>
        this.usuarioService.getPorId(params.get('id'))
      )
    ).subscribe(map => {
      this.usuario = map;
    });

    this.perfilService.getTodos().subscribe(perfis => {
      this.perfis = perfis;
    });
  }

  putUsuario(form: FormGroup) {
    if (form.dirty && form.valid) {
      this.InRequest = true;
      this.usuario = Object.assign({}, new Usuario(), form.value);
      this.usuario.dataDeNascimento =
        `${form.value.dataDeNascimento.year}-${form.value.dataDeNascimento.month}-${form.value.dataDeNascimento.day}`;

      this.usuarioService.put(this.usuario).subscribe(response => {
        this.InRequest = false;
        if (this.errosDeRequest.length === 0) {
          this.toastService.success('Operação realizada com sucesso!');
        }
      });
    }
  }
}
