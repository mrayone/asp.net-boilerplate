import { Component, OnInit, AfterViewInit, ViewChildren, ElementRef } from '@angular/core';
import { FormGroup, FormControl, Validators, FormControlName } from '@angular/forms';
import { NgbDatepickerI18n, NgbDateParserFormatter } from '@ng-bootstrap/ng-bootstrap';
import { CustomDatepickerI18n, I18n } from './customDatePicker/custom-datepicker-i18n';
import { NgbDatePTParserFormatter } from './dateFormatter/ngb-date-ptparser-formatter';
import { merge, Observable, fromEvent } from 'rxjs';
import { GenericValidator } from 'src/app/Utils/generic-validator';
import { mensagensDeErro } from './mensagens-de-erro/mensagens-de-erro';

@Component({
  selector: 'app-formulario-usuario',
  templateUrl: './formulario-usuario.component.html',
  styleUrls: ['./formulario-usuario.component.scss'],
  providers: [
    [I18n, {provide: NgbDatepickerI18n, useClass: CustomDatepickerI18n}],
    [{provide: NgbDateParserFormatter, useClass: NgbDatePTParserFormatter}]
  ]
})
export class FormularioUsuarioComponent implements OnInit, AfterViewInit {

  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];
  usuarioForm: FormGroup;
  genericValidator: GenericValidator;
  erros?: { [key: string]: string } = {};
  constructor() {
    this.genericValidator = new GenericValidator(mensagensDeErro);
   }

  ngOnInit() {
    this.usuarioForm = new FormGroup({
      nome: new FormControl('', [
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(150)
      ]),
      sobrenome: new FormControl('', [
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(150)
      ]),
      sexo: new FormControl('M', [
        Validators.required,
        Validators.pattern(/[F-M]/)
      ]),
      email: new FormControl('', [
        Validators.required,
        Validators.email
      ]),
      cpf: new FormControl('', [
        Validators.required,
        Validators.maxLength(14),
        Validators.minLength(11)
      ]),
      dataDeNascimento: new FormControl('', [
        Validators.required
      ]),
      telefone: new FormControl('',
      [
        Validators.maxLength(13),
        Validators.minLength(11)
      ]),
      celular: new FormControl('',
      [
        Validators.maxLength(15),
        Validators.minLength(11)
      ]),
      logradouro: new FormControl('',
      [
        Validators.minLength(2),
        Validators.maxLength(150)
      ]),
      numero: new FormControl('', [
        Validators.minLength(2),
        Validators.maxLength(10)
      ]),
      complemento: new FormControl('', [
        Validators.minLength(3),
        Validators.maxLength(50)
      ]),
      bairro: new FormControl('',
      [
        Validators.minLength(3),
        Validators.maxLength(150)
      ]),
      cep: new FormControl('',
      [
        Validators.minLength(3),
        Validators.maxLength(150)
      ]),
      cidade: new FormControl('',
      [
        Validators.minLength(3),
        Validators.maxLength(150)
      ]),
      estado: new FormControl('', [
        Validators.minLength(2),
        Validators.maxLength(2)
      ]),
      perfilId: new FormControl(),
      });

  }

  ngAfterViewInit(): void {
    const controlBlurs: Observable<any>[] = this.formInputElements
      .map((formControl: ElementRef) => fromEvent(formControl.nativeElement, 'blur'));

    merge(...controlBlurs).subscribe(value => {
      this.erros = this.genericValidator.processMessages(this.usuarioForm);
    });
  }

}
