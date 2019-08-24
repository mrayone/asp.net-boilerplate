import { Component, OnInit, ViewChildren, QueryList, Input, ElementRef, AfterViewInit } from '@angular/core';
import { Observable } from 'rxjs';
import { NgbdSortableHeader, SortEvent } from './directive/sortable.directive';
import { DataTableService } from './services/data-table-service';
import { DecimalPipe } from '@angular/common';

@Component({
  selector: 'data-table-component',
  templateUrl: './data-table.component.html',
  styleUrls: ['./data-table.component.scss'],
  providers: [DataTableService, DecimalPipe]
})
export class DataTableComponent implements OnInit, AfterViewInit  {
  tabelaItems$: Observable<any[]>;
  total$: Observable<number>;
  objectKeys = Object.keys;
  objectValues = Object.values;
  @Input() tabelaModel: Observable<any[]>;
  @Input() columns: any = {};
  @ViewChildren(NgbdSortableHeader) headers: QueryList<NgbdSortableHeader>;
  constructor(public service: DataTableService,  private elRef:ElementRef) {
    this.tabelaItems$ = service.dados$;
    this.total$ = service.total$;
  }


  ngOnInit(): void {
    this.tabelaModel.subscribe((val) => {
      this.service.dados = val;
      this.service.termsAccepts = this.objectKeys(this.columns);
    });
  }

  onSort({column, direction}: SortEvent) {
    // resetting other headers
    this.headers.forEach(header => {
      if (header.sortable !== column) {
        header.direction = '';
      }
    });

    this.service.sortColumn = column;
    this.service.sortDirection = direction;
  }

  ngAfterViewInit(): void {
  }

  navegar(element: Event) {
    console.log(element);
  }
}
