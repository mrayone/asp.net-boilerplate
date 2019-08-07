import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CardRoundedComponent } from './card-rounded/card-rounded.component';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';
import { ToastComponent } from './toast/toast.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [
    CardRoundedComponent,
    UnauthorizedComponent,
    ToastComponent,
  ],
  imports: [
    CommonModule,
    NgbModule,
  ],
  exports: [
    CardRoundedComponent,
    ToastComponent
  ],
  providers: [
  ]
})
export class SharedModule { }
