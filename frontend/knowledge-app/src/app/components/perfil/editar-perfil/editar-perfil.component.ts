import { Component, OnInit } from '@angular/core';
import { PerfilService } from 'src/app/services/perfil.service';
import { ErrosService } from 'src/app/services/erros.service';
import { ToastrService } from 'ngx-toastr';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { FormType } from 'src/app/Utils/formType/form-type.enum';
import { FormGroup } from '@angular/forms';
import { Perfil } from '../models/perfil';
import { take, switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-editar-perfil',
  templateUrl: './editar-perfil.component.html',
  styleUrls: ['./editar-perfil.component.scss']
})
export class EditarPerfilComponent implements OnInit {

  perfil: Perfil;
  errosDeRequest: string[];
  formType = FormType.Put;

  constructor(private perfilService: PerfilService,
              private erroService: ErrosService, private toastService: ToastrService, private router: Router,
              private route: ActivatedRoute) {
  }

  ngOnInit() {
    this.route.paramMap.pipe(
      switchMap((params: ParamMap) =>
        this.perfilService.getPorId(params.get('id'))
      )
    ).subscribe(map => {
      this.perfil = map;
      this.subscribeErros();
    });
  }

  onPutCommand(form: FormGroup) {
    if (form.dirty && form.valid) {
      const perfil: Perfil = Object.assign({}, new Perfil(), form.value);
      this.perfilService.put(perfil).subscribe(response => {
        if (this.errosDeRequest.length === 0) {
          this.toastService.success('Operação realiza com sucesso!');
          this.router.navigate(['/perfis']);
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
