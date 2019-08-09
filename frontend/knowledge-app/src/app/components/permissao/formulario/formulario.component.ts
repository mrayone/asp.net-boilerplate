import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Permissao } from '../Models/permissao';
import { FormType } from 'src/app/Utils/formType/form-type.enum';

@Component({
  selector: 'app-formulario-permissao',
  templateUrl: './formulario.component.html',
  styleUrls: ['./formulario.component.scss']
})
export class FormularioComponent implements OnInit {

  permissao: FormGroup;
  model: Permissao;
  formType: FormType;
  constructor() { }

  ngOnInit() {
    this.gerarFormulario();
  }

  gerarFormulario() {
    this.permissao = new FormGroup({
      tipo: new FormControl(this.model.tipo, [
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(30)
      ]),
      valor: new FormControl(this.model.valor, [
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(30)
      ]),
    });

  }

}
