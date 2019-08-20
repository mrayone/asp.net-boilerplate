import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CardRoundedComponent } from './card-rounded/card-rounded.component';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { DataTableComponent } from './data-table/data-table.component';
import { FormsModule } from '@angular/forms';
import { SanitizeHtml} from '../../Utils/pipes/sanitizeHtml.pipe';
import { RouterModule } from '@angular/router';
import { NgbdSortableHeader } from './data-table/directive/sortable.directive';
@NgModule({
  declarations: [
    CardRoundedComponent,
    UnauthorizedComponent,
    DataTableComponent,
    SanitizeHtml,
    NgbdSortableHeader
  ],
  imports: [
    CommonModule,
    NgbModule,
    FormsModule,
    RouterModule
  ],
  exports: [
    CardRoundedComponent,
    DataTableComponent,
  ],
  providers: [
  ]
})
export class SharedModule { }
