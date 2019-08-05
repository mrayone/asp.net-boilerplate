import { Component, OnInit } from '@angular/core';
import { FormType } from '../usuario/formulario/formType/form-type.enum';
@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.scss']
})
export class PerfilComponent implements OnInit {

  formType: FormType = FormType.Put;
  constructor() { }

  ngOnInit() {
  }

}
