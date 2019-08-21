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
    private toastService: ToastrService, private router: Router) { }
  formType = FormType.Post;
  ngOnInit() {
  }

  onPostCommand(form: FormGroup) {
    if (form.dirty && form.valid) {
      const permissao: Permissao = Object.assign({}, new Permissao(), form.value);
      this.permissaoService.post(permissao).subscribe(response => {
        this.toastService.success('Operação realiza com sucesso!')
        .onHidden.subscribe(() => this.router.navigate(['/permissoes']));
      });
    }
  }
}
