import { Component, OnInit } from '@angular/core';
import { Usuario } from '../models/usuario';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-adicionar-usuario',
  templateUrl: './adicionar-usuario.component.html',
  styleUrls: ['./adicionar-usuario.component.scss']
})
export class AdicionarUsuarioComponent implements OnInit {
  constructor() { }

  ngOnInit() { }


  onPostCommand(form: FormGroup) {
    if (form.dirty && form.valid) {
      const usuario: Usuario = Object.assign({ }, new Usuario(), form.value);
      usuario.dataDeNascimento =
      `${form.value.dataDeNascimento.year}-${form.value.dataDeNascimento.month}-${form.value.dataDeNascimento.day}`;
    }
  }

}
