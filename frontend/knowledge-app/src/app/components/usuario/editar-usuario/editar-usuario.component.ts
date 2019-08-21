import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { switchMap } from 'rxjs/operators';
import { PerfilService } from 'src/app/services/perfil.service';
import { UsuarioService } from 'src/app/services/usuario.service';
import { FormType } from '../../../Utils/formType/form-type.enum';
import { Perfil } from '../../perfil/models/perfil';
import { Usuario } from '../models/usuario';

@Component({
  selector: 'app-editar-usuario',
  templateUrl: './editar-usuario.component.html',
  styleUrls: ['./editar-usuario.component.scss']
})
export class EditarUsuarioComponent implements OnInit {

  formType: FormType = FormType.Put;
  usuario: Usuario;
  perfis: Perfil[];
  constructor(private usuarioService: UsuarioService, private toastService: ToastrService,  private route: ActivatedRoute,
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
    if (form.valid) {
      this.usuario = Object.assign({}, new Usuario(), form.value);
      this.usuario.dataDeNascimento =
        `${form.value.dataDeNascimento.year}-${form.value.dataDeNascimento.month}-${form.value.dataDeNascimento.day}`;

      this.usuarioService.put(this.usuario).subscribe(response => {
        this.toastService.success('Operação realiza com sucesso!')
        .onHidden.subscribe(() => this.router.navigate(['/usuarios']));
      });
    }
  }
}
