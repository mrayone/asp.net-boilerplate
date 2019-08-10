import { Component, OnInit } from '@angular/core';
import { FormType } from 'src/app/Utils/formType/form-type.enum';
import { PermissaoService } from 'src/app/services/permissao.service';
import { ErrosService } from 'src/app/services/erros.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { FormGroup } from '@angular/forms';
import { Permissao } from '../Models/permissao';
import { take } from 'rxjs/operators';

@Component({
  selector: 'app-adicionar-permissao',
  templateUrl: './adicionar-permissao.component.html',
  styleUrls: ['./adicionar-permissao.component.scss']
})
export class AdicionarPermissaoComponent implements OnInit {

  constructor(private permissaoService: PermissaoService,
    private erroService: ErrosService, private toastService: ToastrService, private router: Router) { }

  errosDeRequest: string[];
  formType = FormType.Post;
  ngOnInit() {

    this.subscribeErros();
  }

  onPostCommand(form: FormGroup) {
    if (form.dirty && form.valid) {
      const permissao: Permissao = Object.assign({ }, new Permissao(), form.value);
      this.permissaoService.post(permissao).subscribe(response => {
         if (this.errosDeRequest.length === 0) {
            this.toastService.success('Operação realiza com sucesso!');
            this.router.navigate(['/permissoes']);
         } else {
           this.checarErrosDeRequest();
         }
      });
    }
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
