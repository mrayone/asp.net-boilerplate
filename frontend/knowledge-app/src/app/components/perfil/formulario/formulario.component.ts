import { Component, OnInit, Input, EventEmitter, Output, ViewChildren, ElementRef, AfterViewInit } from '@angular/core';
import { Perfil } from '../models/perfil';
import { FormType } from 'src/app/Utils/formType/form-type.enum';
import { FormGroup, FormControlName, FormControl, Validators } from '@angular/forms';
import { GenericValidator } from 'src/app/Utils/generic-validator';
import { mensagensDeErroPerfilForm } from './mensagens-de-erro/mensagens-de-erro';
import { Observable, fromEvent, merge } from 'rxjs';
import { PermissaoService } from 'src/app/services/permissao.service';
import { Permissao } from '../../permissao/Models/permissao';

@Component({
  selector: 'app-formulario-perfil',
  templateUrl: './formulario.component.html',
  styleUrls: ['./formulario.component.scss']
})
export class FormularioComponent implements OnInit, AfterViewInit {

  perfilForm: FormGroup;
  private permissoes: Permissao[];
  @Input() model: Perfil;
  @Input() formType: FormType = FormType.Post;
  erros: any = {};
  genericValidator: any;

  @Output() command = new EventEmitter<FormGroup>();
  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

  constructor(private permissoesService: PermissaoService) {
    this.genericValidator = new GenericValidator(mensagensDeErroPerfilForm);
    this.model =  new Perfil();
    this.permissoes = new Array<Permissao>();
   }

  ngOnInit() {
    this.gerarFormulario();

    this.permissoesService.getTodas().subscribe(permissoes => {
      this.permissoes = permissoes;
    });
  }


  get mapPermissoes(): any {
    const permissoes = [];
    this.permissoes.forEach((value, index, array) => {
      const valores = array.filter((el) => el.tipo === value.tipo);
      if (permissoes.findIndex((p) => p.tipo === value.tipo) === -1) {
        permissoes.push({
          tipo: value.tipo,
          valores
        });
      }
    });
    return permissoes;
  }

  gerarFormulario() {
    this.perfilForm = new FormGroup({
      nome: new FormControl(this.model.nome, [
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(50)
      ]),
      descricao: new FormControl(this.model.descricao, [
        Validators.minLength(3),
        Validators.maxLength(150)
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
