import { Component, OnInit, ViewChildren, ElementRef, AfterViewInit, EventEmitter, Output } from '@angular/core';
import { FormGroup, FormControl, Validators, FormControlName } from '@angular/forms';
import { Permissao } from '../Models/permissao';
import { FormType } from 'src/app/Utils/formType/form-type.enum';
import { merge, Observable, fromEvent } from 'rxjs';
import { GenericValidator } from 'src/app/Utils/generic-validator';
import { mensagensDeErroPermissaoForm } from './mensagens-de-erro/mensagens-de-erro';


@Component({
  selector: 'app-formulario-permissao',
  templateUrl: './formulario.component.html',
  styleUrls: ['./formulario.component.scss']
})
export class FormularioComponent implements OnInit, AfterViewInit {

  permissaoForm: FormGroup;
  model: Permissao;
  formType: FormType;
  erros: { [key: string]: string } = {};
  genericValidator: any;

  @Output() command = new EventEmitter<FormGroup>();
  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];
  constructor() {
    this.genericValidator = new GenericValidator(mensagensDeErroPermissaoForm);
   }

  ngOnInit() {
    this.gerarFormulario();
  }

  gerarFormulario() {
    this.permissaoForm = new FormGroup({
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

  ngAfterViewInit(): void {
    const controlBlurs: Observable<any>[] = this.formInputElements
      .map((formControl: ElementRef) => fromEvent(formControl.nativeElement, 'blur'));

    merge(...controlBlurs).subscribe(value => {
      this.erros = this.genericValidator.processMessages(this.permissaoForm);
    });
  }

  sendCommand() {
    this.command.emit(this.permissaoForm);
  }

}
