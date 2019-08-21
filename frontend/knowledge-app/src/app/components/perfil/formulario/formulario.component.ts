import { Component, OnInit, Input, EventEmitter, Output, ViewChildren, ElementRef, AfterViewInit } from '@angular/core';
import { Perfil } from '../models/perfil';
import { FormType } from 'src/app/Utils/formType/form-type.enum';
import { FormGroup, FormControlName, FormControl, Validators, FormArray } from '@angular/forms';
import { GenericValidator } from 'src/app/Utils/generic-validator';
import { mensagensDeErroPerfilForm } from './mensagens-de-erro/mensagens-de-erro';
import { Observable, fromEvent, merge } from 'rxjs';
import { PermissaoService } from 'src/app/services/permissao.service';
import { Permissao } from '../../permissao/Models/permissao';
import * as _ from "lodash";
import { InrequestService } from 'src/app/services/inrequest.service';
@Component({
  selector: 'app-formulario-perfil',
  templateUrl: './formulario.component.html',
  styleUrls: ['./formulario.component.scss']
})
export class FormularioComponent implements OnInit, AfterViewInit {

  perfilForm: FormGroup;
  permissoes: Permissao[];
  erros: any = {};
  genericValidator: any;
  @Input() model: Perfil;
  @Input() formType: FormType = FormType.Post;
  @Output() command = new EventEmitter<FormGroup>();
  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

  constructor(private permissoesService: PermissaoService, public inRequestService: InrequestService) {
    this.genericValidator = new GenericValidator(mensagensDeErroPerfilForm);
    this.model = new Perfil();
    this.permissoes = new Array<Permissao>();
  }

  ngOnInit() {
    this.permissoesService.getTodas().subscribe(permissoes => {
      this.permissoes = permissoes.sort(this.ordemAlfabetica);
      this.gerarFields();
    });
    this.gerarFormulario();
  }

  ordemAlfabetica(a: Permissao, b: Permissao) {
    if (a.tipo < b.tipo) {
      return -1;
    } else if (a.tipo > b.tipo) {
      return 1;
    }
    return 0;
  }

  gerarFields() {
    const array = [];
    this.permissoes.forEach((el) => {
      const permissaoPerfil = this.model.atribuicoes.find((atr) => atr.permissaoId === el.id);
      if (permissaoPerfil) {
        const { permissaoId, ativo } = permissaoPerfil;
        array.push(new FormControl({ permissaoId, ativo }));
      } else {
        array.push(new FormControl());
      }
    });

    this.perfilForm.addControl('atribuicoes', new FormArray(array));
  }

  radioAtivo(index, value): boolean {
    const control = this.perfilForm.value.atribuicoes[index];
    if (control) {
      return control.ativo === value.ativo;
    }
    return false;
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
      ])
    });

    if (this.formType === FormType.Put) {
      this.perfilForm.addControl('id', new FormControl(this.model.id)
      );
    }
  }

  criarValor(permissaoId, ativo) {

    return { permissaoId, ativo };
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
    this.inRequestService.startRequest();
  }
}

