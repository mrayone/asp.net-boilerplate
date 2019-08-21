import { Component, OnInit } from '@angular/core';
import { Usuario } from '../models/usuario';
import { UsuarioService } from 'src/app/services/usuario.service';
import { Router, Route, ActivatedRoute, ParamMap } from '@angular/router';
import { switchMap, take } from 'rxjs/operators';
import { Observable } from 'rxjs';
import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';
import { ErrosService } from 'src/app/services/erros.service';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-usuario-detalhes',
  templateUrl: './usuario-detalhes.component.html',
  styleUrls: ['./usuario-detalhes.component.scss']
})
export class UsuarioDetalhesComponent implements OnInit {

  usuario: Usuario;
  closeResult: string;
  errosDeRequest: string[];
  constructor(private usuarioService: UsuarioService,
              private route: ActivatedRoute, private router: Router,
              private modalService: NgbModal,
              private toastService: ToastrService) {
   }
  ngOnInit() {
   this.route.paramMap.pipe(
      switchMap( (params: ParamMap) =>
       this.usuarioService.getPorId(params.get('id'))
      )
    ).subscribe(map => {
      this.usuario = map;
    });
  }

  open(content) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
      this.deletarUsuario(this.closeResult);
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

  private deletarUsuario(result: string) {
    if (result === `Closed with: Ok click`) {
        this.usuarioService.delete(this.usuario.id)
        .subscribe(() => {
            this.toastService.success('Operação realizada com sucesso!');
            this.router.navigate(['/usuarios']);
        });
    }
  }
}
