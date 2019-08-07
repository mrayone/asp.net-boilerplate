import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ErrosService } from 'src/app/services/erros.service';
import { Observable, observable } from 'rxjs';
@Component({
  selector: 'app-toast',
  templateUrl: './toast.component.html',
  styleUrls: ['./toast.component.scss']
})
export class ToastComponent implements OnInit {
  @Input() mostrarToast: boolean;
  esconderToast = false;
  @Input() tipoToast = '';
  @Input() toastBody: any[];
  // tslint:disable-next-line: no-output-native
  @Output() close = new EventEmitter<boolean>();

  constructor(public erroService: ErrosService) { }

  fecharToast() {
    this.esconderToast = false;
    this.close.emit(true);
  }

  ngOnInit() {
  }
}

export enum ToastType {
  Success = 1,
  Error = 2,
  Notify = 3
}
