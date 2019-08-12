import { Component, OnInit, Input, EventEmitter, Output, ViewChildren, ElementRef, AfterViewInit } from '@angular/core';
import { Perfil } from '../models/perfil';
import { FormType } from 'src/app/Utils/formType/form-type.enum';
import { FormGroup, FormControlName, FormControl, Validators } from '@angular/forms';
import { GenericValidator } from 'src/app/Utils/generic-validator';
import { mensagensDeErroPerfilForm } from './mensagens-de-erro/mensagens-de-erro';
import { Observable, fromEvent, merge } from 'rxjs';

@Component({
  selector: 'app-formulario-perfil',
  templateUrl: './formulario.component.html',
  styleUrls: ['./formulario.component.scss']
})
export class FormularioComponent implements OnInit, AfterViewInit {

  perfilForm: FormGroup;
  @Input() model: Perfil;
  @Input() formType: FormType = FormType.Post;
  erros: { [key: string]: string } = {};
  genericValidator: any;

  @Output() command = new EventEmitter<FormGroup>();
  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

  constructor() {
    this.genericValidator = new GenericValidator(mensagensDeErroPerfilForm);
    this.model =  new Perfil();
   }

  ngOnInit() {
    this.gerarFormulario();
  }

  gerarFormulario() {
    this.perfilForm = new FormGroup({
      tipo: new FormControl(this.model.nome, [
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(30)
      ]),
      valor: new FormControl(this.model.descricao, [
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(30)
      ]),
    });

    if (this.formType === FormType.Put) {
      this.perfilForm.addControl('id', new FormControl(this.model.id)
      );
    }
  }

  ngAfterViewInit(): void {
    const controlBlurs: Observable<any>[] = this.formInputElements
      .map((formControl: ElementRef) => fromEvent(formControl.nativeElement, 'blur'));

    merge(...controlBlurs).subscribe(value => {
      this.erros = this.genericValidator.processMessages(this.perfilForm);
    });
  }

  sendCommand() {
    this.command.emit(this.perfilForm);
  }
}
