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
    private toastService: ToastrService, private router: Router) { }

  perfis: Perfil[];
  ngOnInit() {
    this.perfilService.getTodos().subscribe(perfis => {
      this.perfis = perfis;
    });
  }

  onPostCommand(form: FormGroup) {
    if (form.dirty && form.valid) {
      const usuario: Usuario = Object.assign({}, new Usuario(), form.value);
      usuario.dataDeNascimento =
        `${form.value.dataDeNascimento.year}-${form.value.dataDeNascimento.month}-${form.value.dataDeNascimento.day}`;

      this.usuarioService.post(usuario).subscribe(response => {
        this.toastService.success('Operação realiza com sucesso!')
          .onHidden.subscribe(() => this.router.navigate(['/usuarios']));
      });
    }
  }
}
