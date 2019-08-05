import { Component, OnInit, AfterViewInit, ViewChildren, ElementRef, Input, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormControl, Validators, FormControlName } from '@angular/forms';
import { NgbDatepickerI18n, NgbDateParserFormatter } from '@ng-bootstrap/ng-bootstrap';
import { CustomDatepickerI18n, I18n } from './customDatePicker/custom-datepicker-i18n';
import { NgbDatePTParserFormatter } from './dateFormatter/ngb-date-ptparser-formatter';
import { merge, Observable, fromEvent } from 'rxjs';
import { GenericValidator } from 'src/app/Utils/generic-validator';
import { mensagensDeErro } from './mensagens-de-erro/mensagens-de-erro';
import { Usuario } from '../models/usuario';
import { FormType } from './formType/form-type.enum';


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
  @Input() usuario: Usuario;
  @Input() formType: FormType =  FormType.Post;
  @Input() adminInput: boolean;
  @Output() command = new EventEmitter<boolean>();

  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];
  usuarioForm: FormGroup;
  genericValidator: GenericValidator;
  erros?: { [key: string]: string } = {};
  constructor() {
    this.genericValidator = new GenericValidator(mensagensDeErro);
   }

  ngOnInit() {
    this.gerarFormulario();
  }

  sendCommand() {
    this.command.emit();
  }

  gerarFormulario(): void {
    this.usuario = !this.usuario ? new Usuario() : this.usuario;
    this.usuarioForm = new FormGroup({
      nome: new FormControl(this.usuario.nome, [
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(150)
      ]),
      sobrenome: new FormControl(this.usuario.sobrenome, [
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(150)
      ]),
      sexo: new FormControl(this.usuario.sexo, [
        Validators.required,
        Validators.pattern(/[F-M]/)
      ]),
      email: new FormControl(this.usuario.email, [
        Validators.required,
        Validators.email
      ]),
      cpf: new FormControl(this.usuario.cpf, [
        Validators.required,
        Validators.maxLength(14),
        Validators.minLength(11)
      ]),
      dataDeNascimento: new FormControl(this.usuario.dateDeNascimento, [
        Validators.required
      ]),
      telefone: new FormControl(this.usuario.telefone,
      [
        Validators.maxLength(13),
        Validators.minLength(11)
      ]),
      celular: new FormControl(this.usuario.celular,
      [
        Validators.maxLength(15),
        Validators.minLength(11)
      ]),
      logradouro: new FormControl(this.usuario.logradouro,
      [
        Validators.minLength(2),
        Validators.maxLength(150)
      ]),
      numero: new FormControl(this.usuario.numero, [
        Validators.minLength(2),
        Validators.maxLength(10)
      ]),
      complemento: new FormControl(this.usuario.complemento, [
        Validators.minLength(3),
        Validators.maxLength(50)
      ]),
      bairro: new FormControl(this.usuario.bairro,
      [
        Validators.minLength(3),
        Validators.maxLength(150)
      ]),
      cep: new FormControl(this.usuario.cep,
      [
        Validators.minLength(8),
        Validators.maxLength(9)
      ]),
      cidade: new FormControl(this.usuario.cidade,
      [
        Validators.minLength(3),
        Validators.maxLength(150)
      ]),
      estado: new FormControl(this.usuario.estado, [
        Validators.minLength(2),
        Validators.maxLength(2)
      ])
    });

    if ( this.adminInput ) {
      this.usuarioForm.addControl('perfilId', new FormControl('', [
          Validators.required
        ])
      );
    }
  }

  ngAfterViewInit(): void {
    const controlBlurs: Observable<any>[] = this.formInputElements
      .map((formControl: ElementRef) => fromEvent(formControl.nativeElement, 'blur'));

    merge(...controlBlurs).subscribe(value => {
      this.erros = this.genericValidator.processMessages(this.usuarioForm);
    });
  }

}
