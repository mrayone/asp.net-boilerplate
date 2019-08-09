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
import { Perfil } from '../../perfil/models/perfil';
import { CustomValidators } from 'ng2-validation';

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
  @Input() model: Usuario;
  @Input() formType: FormType =  FormType.Post;
  @Input() adminInput: boolean;
  @Input() perfis: Perfil[];
  @Output() command = new EventEmitter<FormGroup>();

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
    this.command.emit(this.usuarioForm);
  }

  gerarFormulario(): void {
    this.model = !this.model ? new Usuario() : this.filtraModel(this.model);
    this.usuarioForm = new FormGroup({
      nome: new FormControl(this.model.nome, [
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(150)
      ]),
      sobrenome: new FormControl(this.model.sobrenome, [
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(150)
      ]),
      sexo: new FormControl(this.model.sexo, [
        Validators.required,
        Validators.pattern(/[F-M]/)
      ]),
      email: new FormControl(this.model.email, [
        Validators.required,
        CustomValidators.email
      ]),
      cpf: new FormControl(this.model.cpf, [
        Validators.required,
        Validators.maxLength(14),
        Validators.minLength(11)
      ]),
      dataDeNascimento: new FormControl(this.model.dataDeNascimento, [
        Validators.required
      ]),
      telefone: new FormControl(this.model.telefone,
      [
        Validators.maxLength(13),
        Validators.minLength(10)
      ]),
      celular: new FormControl(this.model.celular,
      [
        Validators.maxLength(15),
        Validators.minLength(11)
      ]),
      logradouro: new FormControl(this.model.logradouro,
      [
        Validators.minLength(2),
        Validators.maxLength(150)
      ]),
      numero: new FormControl(this.model.numero, [
        Validators.minLength(2),
        Validators.maxLength(10)
      ]),
      complemento: new FormControl(this.model.complemento, [
        Validators.minLength(3),
        Validators.maxLength(50)
      ]),
      bairro: new FormControl(this.model.bairro,
      [
        Validators.minLength(3),
        Validators.maxLength(150)
      ]),
      cep: new FormControl(this.model.cep,
      [
        Validators.minLength(8),
        Validators.maxLength(9)
      ]),
      cidade: new FormControl(this.model.cidade,
      [
        Validators.minLength(3),
        Validators.maxLength(150)
      ]),
      estado: new FormControl(this.model.estado, [
        Validators.minLength(2),
        Validators.maxLength(2)
      ])
    });

    if ( this.adminInput ) {
      this.usuarioForm.addControl('perfilId', new FormControl(this.model.perfilId, [
          Validators.required
        ])
      );
    }
  }


  filtraModel(usuario: Usuario) {
    const data = new Date(usuario.dataDeNascimento);
    const year = data.getUTCFullYear();
    const month = data.getMonth() + 1;
    const day = data.getDate();
    usuario.dataDeNascimento = { year, month, day};
    return usuario;
  }

  ngAfterViewInit(): void {
    const controlBlurs: Observable<any>[] = this.formInputElements
      .map((formControl: ElementRef) => fromEvent(formControl.nativeElement, 'blur'));

    merge(...controlBlurs).subscribe(value => {
      this.erros = this.genericValidator.processMessages(this.usuarioForm);
    });
  }

}
