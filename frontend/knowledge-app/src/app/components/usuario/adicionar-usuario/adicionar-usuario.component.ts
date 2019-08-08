import { Component, OnInit } from '@angular/core';
import { Usuario } from '../models/usuario';
import { FormGroup } from '@angular/forms';
import { UsuarioService } from 'src/app/services/usuario.service';
import { Perfil } from '../../perfil/models/perfil';
import { PerfilService } from 'src/app/services/perfil.service';
import { ErrosService } from 'src/app/services/erros.service';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs/operators';
import { Router } from '@angular/router';

@Component({
  selector: 'app-adicionar-usuario',
  templateUrl: './adicionar-usuario.component.html',
  styleUrls: ['./adicionar-usuario.component.scss']
})
export class AdicionarUsuarioComponent implements OnInit {
  constructor(private usuarioService: UsuarioService, private perfilService: PerfilService,
    private erroService: ErrosService, private toastService: ToastrService, private router: Router) { }

  perfis: Perfil[];
  errosDeRequest: string[];
  ngOnInit() {
    this.perfilService.getPerfis().subscribe(perfis => {
        this.perfis = perfis;
    });

    this.subscribeErros();
  }

  onPostCommand(form: FormGroup) {
    if (form.dirty && form.valid) {
      const usuario: Usuario = Object.assign({ }, new Usuario(), form.value);
      usuario.dataDeNascimento =
      `${form.value.dataDeNascimento.year}-${form.value.dataDeNascimento.month}-${form.value.dataDeNascimento.day}`;

      this.usuarioService.post(usuario).subscribe(response => {
         if (this.errosDeRequest.length === 0) {
            this.toastService.success('Operação realizca com sucesso!')
                .onHidden.subscribe(() => this.router.navigate(['/usuarios']));
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
      .subscribe(() => this.close());
    }
  }

  private subscribeErros() {
    this.erroService.getErros().subscribe(erros => {
      this.errosDeRequest = erros;
    });
  }

  close() {
    this.erroService.limparErros();
  }

}
