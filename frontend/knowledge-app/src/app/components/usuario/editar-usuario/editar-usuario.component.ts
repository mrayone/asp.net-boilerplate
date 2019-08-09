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
  constructor(private usuarioService: UsuarioService, private toastService: ToastrService, private route: ActivatedRoute,
              private router: Router, private perfilService: PerfilService,
              private erroService: ErrosService) {

  }

  ngOnInit() {
    this.route.paramMap.pipe(
      switchMap((params: ParamMap) =>
        this.usuarioService.getPorId(params.get('id'))
      )
    ).subscribe(map => {
      this.usuario = map;
      this.subscribeErros();
    });

    this.perfilService.getPerfis().subscribe(perfis => {
      this.perfis = perfis;
  });
  }

  private subscribeErros() {
    this.erroService.getErros().subscribe(erros => {
      this.errosDeRequest = erros;
    });
  }

  putUsuario(form: FormGroup) {
    if (form.dirty && form.valid) {
      this.usuario = Object.assign({}, new Usuario(), form.value);
      this.usuario.dataDeNascimento =
        `${form.value.dataDeNascimento.year}-${form.value.dataDeNascimento.month}-${form.value.dataDeNascimento.day}`;

      this.usuarioService.put(this.usuario).subscribe(response => {
        if (this.errosDeRequest.length === 0) {
          this.toastService.success('Operação realizada com sucesso!');
        } else {
          this.checarErrosDeRequest();
        }
      });
    }
  }

  checarErrosDeRequest() {
    if (this.errosDeRequest.length > 0) {
      const erros = this.errosDeRequest.reduce((acc, next) => {
        return `<p>${acc}</p>` + `<p>${next}</p>`;
      });
      this.toastService.error(erros, 'Erros', {
        enableHtml: true,
        disableTimeOut: true
      }).onTap.pipe(take(1))
        .subscribe(() => this.erroService.limparErros());
    }
  }

}
