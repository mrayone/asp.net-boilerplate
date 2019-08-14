import { Component, OnInit } from '@angular/core';
import { FormType } from 'src/app/Utils/formType/form-type.enum';
import { ErrosService } from 'src/app/services/erros.service';
import { PermissaoService } from 'src/app/services/permissao.service';
import { ToastrService } from 'ngx-toastr';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { FormGroup } from '@angular/forms';
import { Permissao } from '../Models/permissao';
import { take, switchMap } from 'rxjs/operators';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-editar-permissao',
  templateUrl: './editar-permissao.component.html',
  styleUrls: ['./editar-permissao.component.scss']
})
export class EditarPermissaoComponent implements OnInit {

  constructor(private permissaoService: PermissaoService,
              private route: ActivatedRoute, private router: Router,
              private toastService: ToastrService) { }

    permissao: Permissao;
    errosDeRequest: string[];
    formType = FormType.Put;
    ngOnInit() {
      this.route.paramMap.pipe(
        switchMap((params: ParamMap) =>
          this.permissaoService.getPorId(params.get('id'))
        )
      ).subscribe(map => {
        this.permissao = map;
      });
    }

    onPutCommand(form: FormGroup) {
      if ( form.valid ) {
        const permissao: Permissao = Object.assign({}, new Permissao(), form.value);
        this.permissaoService.put(permissao).subscribe(response => {
            this.toastService.success('Operação realiza com sucesso!');
            this.router.navigate(['/permissoes']);
        });
      }
    }
}
