import { Component, OnInit } from '@angular/core';
import { ErrosService } from 'src/app/services/erros.service';
import { Observable, observable } from 'rxjs';

@Component({
  selector: 'app-toast',
  templateUrl: './toast.component.html',
  styleUrls: ['./toast.component.scss']
})
export class ToastComponent implements OnInit {

  erros: string[];
  show = true;
  constructor(public erroService: ErrosService) {
    this.erros = [];
  }

  ngOnInit() {
    this.subscribeErros();
  }

  close() {
    this.erroService.limparErros();
  }

  private subscribeErros() {
    this.erroService.getErros().subscribe(erros => {
      this.erros = erros;
    });
  }

}
