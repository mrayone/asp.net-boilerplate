import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CardRoundedComponent } from './card-rounded/card-rounded.component';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';

@NgModule({
  declarations: [
    CardRoundedComponent,
    UnauthorizedComponent
  ],
  imports: [
    CommonModule,
  ],
  exports: [
    CardRoundedComponent,
  ]
})
export class SharedModule { }
