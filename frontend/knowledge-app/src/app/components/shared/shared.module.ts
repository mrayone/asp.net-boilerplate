import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CardRoundedComponent } from './card-rounded/card-rounded.component';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [
    CardRoundedComponent,
    UnauthorizedComponent
  ],
  imports: [
    CommonModule,
    NgbModule,
  ],
  exports: [
    CardRoundedComponent
  ],
  providers: [
  ]
})
export class SharedModule { }
