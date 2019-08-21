import { Component, OnInit } from '@angular/core';
import { FormType } from '../../../Utils/formType/form-type.enum';
import { Usuario } from '../models/usuario';
import { UsuarioService } from 'src/app/services/usuario.service';
import { FormGroup } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { InrequestService } from 'src/app/services/inrequest.service';

@Component({
  selector: 'app-perfil-usuario',
  templateUrl: './perfil-usuario.component.html',
  styleUrls: ['./perfil-usuario.component.scss']
})
export class PerfilUsuarioComponent implements OnInit {

  formType: FormType = FormType.Put;
  trocarSenhaForm: FormGroup;
  usuario: Usuario;
  closeResult: string;
  errosDeRequest: string[];
  constructor(private usuarioService: UsuarioService,
    private modalService: NgbModal,
    public inRequestService: InrequestService,
    private toastService: ToastrService) {
  }

  ngOnInit() {
    this.usuarioService.getUsuarioInfo().subscribe(usuario => {
      this.usuario = usuario;
    });
  }

  putNovaSenha(form: FormGroup) {
    if (form.dirty && form.valid) {
      const { senha, senhaAtual, confirmaSenha } = form.value;
      this.usuarioService.putTrocarSenha(senha, senhaAtual, confirmaSenha)
        .subscribe(val => {
          this.toastService.success('Operação realizada com sucesso!');
        });
    }
  }
  open(content) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
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
      return `with: ${reason}`;
    }
  }

  putUsuarioPerfil(form: FormGroup) {
    if (form.valid) {
      const usuario: Usuario = Object.assign({}, new Usuario(), form.value);
      usuario.dataDeNascimento =
        `${form.value.dataDeNascimento.year}-${form.value.dataDeNascimento.month}-${form.value.dataDeNascimento.day}`;

      this.usuarioService.putUsuarioPerfil(usuario).subscribe(response => {
        this.toastService.success('Operação realizada com sucesso!');
      });
    }
  }
}
