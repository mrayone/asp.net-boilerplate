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
    private toastService: ToastrService, private router: Router) { }

  errosDeRequest: string[];
  formType = FormType.Post;
  inRequest = false;
  ngOnInit() {

  }

  onPostCommand(form: FormGroup) {
    if (form.dirty && form.valid) {
      this.inRequest = true;
      const perfil: Perfil = Object.assign({}, new Perfil(), form.value);
      perfil.atribuicoes = perfil.atribuicoes.filter(this.sanitizeAtribuicoes);
      this.perfilService.post(perfil).subscribe(response => {
        this.toastService.success('Operação realiza com sucesso!');
        this.router.navigate(['/perfis']);
      });
    }
  }

  sanitizeAtribuicoes(el, i, arr) {
    if (el !== null) { return el; }
  }
}
