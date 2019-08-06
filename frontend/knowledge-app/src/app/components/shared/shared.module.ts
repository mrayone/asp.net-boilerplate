import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CardRoundedComponent } from './card-rounded/card-rounded.component';
@NgModule({
  declarations: [
    CardRoundedComponent
  ],
  imports: [
    CommonModule,
  ],
  exports: [
    CardRoundedComponent,
  ]
})
export class SharedModule { }
