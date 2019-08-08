import { Component, OnInit } from '@angular/core';
import { Usuario } from '../models/usuario';
import { FormGroup } from '@angular/forms';
import { UsuarioService } from 'src/app/services/usuario.service';
import { Perfil } from '../../perfil/models/perfil';
import { PerfilService } from 'src/app/services/perfil.service';
import { ErrosService } from 'src/app/services/erros.service';

@Component({
  selector: 'app-adicionar-usuario',
  templateUrl: './adicionar-usuario.component.html',
  styleUrls: ['./adicionar-usuario.component.scss']
})
export class AdicionarUsuarioComponent implements OnInit {
  constructor(private usuarioService: UsuarioService, private perfilService: PerfilService, private erroService: ErrosService) { }

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
         console.log(response);
      });

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
