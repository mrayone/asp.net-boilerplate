import { Component, OnInit } from '@angular/core';
import { Perfil } from '../models/perfil';
import { PerfilService } from 'src/app/services/perfil.service';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { ErrosService } from 'src/app/services/erros.service';
import { ToastrService } from 'ngx-toastr';
import { switchMap, take } from 'rxjs/operators';

@Component({
  selector: 'app-detalhes-perfil',
  templateUrl: './detalhes-perfil.component.html',
  styleUrls: ['./detalhes-perfil.component.scss']
})
export class DetalhesPerfilComponent implements OnInit {

  perfil: Perfil;
  closeResult: string;
  errosDeRequest: string[];
  constructor(private perfilService: PerfilService,
              private route: ActivatedRoute, private router: Router,
              private modalService: NgbModal,
              private erroService: ErrosService,
              private toastService: ToastrService) {
   }
  ngOnInit() {
   this.route.paramMap.pipe(
      switchMap( (params: ParamMap) =>
       this.perfilService.getPorId(params.get('id'))
      )
    ).subscribe(map => {
      this.perfil = map;
      this.subscribeErros();
    });
  }

  open(content) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
      this.deletarPerfil(this.closeResult);
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  }

  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return  `with: ${reason}`;
    }
  }

  private subscribeErros() {
    this.erroService.getErros().subscribe(erros => {
      this.errosDeRequest = erros;
    });
  }

  private deletarPerfil(result: string) {
    if (result === `Closed with: Ok click`) {
        this.perfilService.delete(this.perfil.id)
        .subscribe(() => {
          if (this.errosDeRequest.length === 0) {
            this.toastService.success('Operação realizada com sucesso!');
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
        .subscribe(() => this.erroService.limparErros());
    }
  }
}
