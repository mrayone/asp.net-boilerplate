import { Component, OnInit } from '@angular/core';
import { PerfilService } from 'src/app/services/perfil.service';
import { ErrosService } from 'src/app/services/erros.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { Perfil } from '../models/perfil';
import { FormGroup } from '@angular/forms';
import { take } from 'rxjs/operators';
import { FormType } from 'src/app/Utils/formType/form-type.enum';

@Component({
  selector: 'app-adicionar-perfil',
  templateUrl: './adicionar-perfil.component.html',
  styleUrls: ['./adicionar-perfil.component.scss']
})
export class AdicionarPerfilComponent implements OnInit {

  constructor(private perfilService: PerfilService,
              private erroService: ErrosService, private toastService: ToastrService, private router: Router) { }

  errosDeRequest: string[];
  formType = FormType.Post;
  inRequest = false;
  ngOnInit() {

    this.subscribeErros();
  }

  onPostCommand(form: FormGroup) {
    if (form.dirty && form.valid) {
      this.inRequest = true;
      const perfil: Perfil = Object.assign({ }, new Perfil(), form.value);
      perfil.atribuicoes = perfil.atribuicoes.filter(this.sanitizeAtribuicoes);
      this.perfilService.post(perfil).subscribe(response => {
         if (this.errosDeRequest.length === 0) {
            this.toastService.success('Operação realiza com sucesso!');
            this.router.navigate(['/perfis']);
         } else {
           this.checarErrosDeRequest();
         }
         this.inRequest = false;
      });
    }
  }

  sanitizeAtribuicoes(el, i, arr) {
    if (el !== null) { return el; }
  }

  checarErrosDeRequest() {
    if (this.errosDeRequest.length > 0) {
      const erros = this.errosDeRequest.reduce((acc, next) => {
        return `<p>${acc}</p>` + `<p>${next}</p>`;
      });
      this.toastService.error(erros, 'Erros', {
        enableHtml: true,
        disableTimeOut: true
      }).onTap.pipe(take(1))
      .subscribe(() => this.close());
    }
  }

  private subscribeErros() {
    this.erroService.getErros().subscribe(erros => {
      this.errosDeRequest = erros;
    });
  }

  close() {
    this.erroService.limparErros();
  }
}
