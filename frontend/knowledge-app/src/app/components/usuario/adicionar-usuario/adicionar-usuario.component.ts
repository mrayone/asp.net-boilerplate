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


  onPostCommand(formValue: FormGroup) {
    const usuario: Usuario = Object.assign({ }, new Usuario(), formValue.value);
    usuario.dataDeNascimento =
    `${formValue.value.dataDeNascimento.year}-${formValue.value.dataDeNascimento.month}-${formValue.value.dataDeNascimento.day}`;
  }

}
