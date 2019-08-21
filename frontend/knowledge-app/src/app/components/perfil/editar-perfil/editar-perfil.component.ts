import { Component, OnInit } from '@angular/core';
import { PerfilService } from 'src/app/services/perfil.service';
import { ToastrService } from 'ngx-toastr';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { FormType } from 'src/app/Utils/formType/form-type.enum';
import { FormGroup } from '@angular/forms';
import { Perfil } from '../models/perfil';
import { switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-editar-perfil',
  templateUrl: './editar-perfil.component.html',
  styleUrls: ['./editar-perfil.component.scss']
})
export class EditarPerfilComponent implements OnInit {

  perfil: Perfil;
  errosDeRequest: string[];
  formType = FormType.Put;
  inRequest = false;
  constructor(private perfilService: PerfilService, private toastService: ToastrService, private router: Router,
              private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.paramMap.pipe(
      switchMap((params: ParamMap) =>
        this.perfilService.getPorId(params.get('id'))
      )
    ).subscribe(map => {
      this.perfil = map;
    });
  }

  onPutCommand(form: FormGroup) {
    if (form.valid) {
      this.inRequest = true;
      const perfil: Perfil = Object.assign({}, new Perfil(), form.value);
      perfil.atribuicoes = perfil.atribuicoes.filter(this.sanitizeAtribuicoes);
      this.perfilService.put(perfil).subscribe(response => {
        this.toastService.success('Operação realiza com sucesso!')
        .onHidden.subscribe(() => this.router.navigate(['/perfis']));
      });
    }
  }
  sanitizeAtribuicoes(el, i, arr) {
    if (el !== null) { return el; }
  }
}
