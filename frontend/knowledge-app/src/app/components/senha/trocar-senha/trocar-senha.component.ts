import { Component, OnInit, AfterViewInit, ViewChildren, ElementRef, Input, EventEmitter, Output } from '@angular/core';
import { InrequestService } from 'src/app/services/inrequest.service';
import { FormControlName, FormGroup, Validators, FormControl } from '@angular/forms';
import { GenericValidator, MustMatch } from 'src/app/Utils/generic-validator';
import { Observable, fromEvent, merge } from 'rxjs';
import { mensagensDeErro } from './mensagens-de-erro/mensagens';

@Component({
  selector: 'app-trocar-senha',
  templateUrl: './trocar-senha.component.html',
  styleUrls: ['./trocar-senha.component.scss']
})
export class TrocarSenhaComponent implements OnInit, AfterViewInit  {
  @ViewChildren(FormControlName, { read: ElementRef }) formElements: ElementRef[];
  @Output() command = new EventEmitter<FormGroup>();
  trocarSenhaForm: FormGroup;
  closeResult: string;
  erros: any = {};
  genericValidator: GenericValidator;
  constructor(public inRequestService: InrequestService) {
      this.genericValidator = new GenericValidator(mensagensDeErro);
    }

  ngOnInit() {
    this.initForm();
  }


  sendCommand() {
    this.command.emit(this.trocarSenhaForm);
    this.inRequestService.startRequest();
  }

  initForm() {
    this.trocarSenhaForm = new FormGroup({
      senha: new FormControl('', [
        Validators.required,
        Validators.minLength(8)
      ]),
      senhaAtual: new FormControl('', [
        Validators.required,
        Validators.minLength(8),
        Validators.maxLength(20)
      ]),
      confirmaSenha: new FormControl(''),
    }, { validators: MustMatch('senha', 'confirmaSenha') });
  }

  ngAfterViewInit(): void {
    console.log('afterinit');
    const controlBlurs: Observable<any>[] = this.formElements
      .map((formControl: ElementRef) => fromEvent(formControl.nativeElement, 'blur'));

    merge(...controlBlurs).subscribe(value => {
      this.erros = this.genericValidator.processMessages(this.trocarSenhaForm);
    });
  }

}
