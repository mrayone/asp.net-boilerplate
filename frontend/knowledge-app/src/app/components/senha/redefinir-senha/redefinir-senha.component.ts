import { Component, OnInit, AfterViewInit, ViewChildren, ElementRef } from '@angular/core';
import { FormGroup, FormControlName, FormControl, Validators } from '@angular/forms';
import { GenericValidator, MustMatch } from 'src/app/Utils/generic-validator';
import { InrequestService } from 'src/app/services/inrequest.service';
import { ParamMap, ActivatedRoute } from '@angular/router';
import { Observable, fromEvent, merge } from 'rxjs';
import { mensagensDeErro } from './mensagens-de-erro/mensagens';
import { UsuarioService } from 'src/app/services/usuario.service';
import { ToastrService } from 'ngx-toastr';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-redefinir-senha',
  templateUrl: './redefinir-senha.component.html',
  styleUrls: ['./redefinir-senha.component.scss']
})
export class RedefinirSenhaComponent implements OnInit, AfterViewInit {
  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];
  genericValidator: GenericValidator;
  erros: any = {};
  recuperarSenhaForm: FormGroup;

  constructor(private usuarioService: UsuarioService,
    private route: ActivatedRoute, public inRequestService: InrequestService,
    private toastService: ToastrService) {
    this.genericValidator = new GenericValidator(mensagensDeErro);
  }

  ngOnInit() {
    this.formInit();
    this.route.paramMap.pipe(
      map((params: ParamMap) => {
        console.log(params.get('token'));
      })
    ).subscribe(map => {

    });
  }


  alterarSenha(): void {
    if (this.recuperarSenhaForm.valid) {

    }
  }

  private formInit() {
    this.recuperarSenhaForm = new FormGroup({
      email: new FormControl('', [Validators.email, Validators.required]),
      senha: new FormControl('', [Validators.required, Validators.minLength(6)]),
      confirmaSenha: new FormControl('', [Validators.required])
    }, { validators: MustMatch('senha', 'confirmaSenha') });
  }

  ngAfterViewInit(): void {
    const controlBlurs: Observable<any>[] = this.formInputElements
      .map((formControl: ElementRef) => fromEvent(formControl.nativeElement, 'blur'));

    merge(...controlBlurs).subscribe(value => {
      this.erros = this.genericValidator.processMessages(this.recuperarSenhaForm);
    });
  }
}
