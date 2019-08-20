import { Injectable, PipeTransform } from '@angular/core';

import { BehaviorSubject, Observable, of, Subject } from 'rxjs';

import { DecimalPipe } from '@angular/common';
import { debounceTime, delay, switchMap, tap } from 'rxjs/operators';
import { SortDirection } from '../directive/sortable.directive';

interface SearchResult {
  dados: any[];
  total: number;
}

interface State {
  page: number;
  pageSize: number;
  searchTerm: string;
  sortColumn: string;
  sortDirection: SortDirection;
}

function compare(v1, v2) {
  return v1 < v2 ? -1 : v1 > v2 ? 1 : 0;
}

function sort(valores: any[], column: string, direction: string): any[] {
  if (direction === '') {
    return valores;
  } else {
    return [...valores].sort((a, b) => {
      const res = compare(a[column], b[column]);
      return direction === 'asc' ? res : -res;
    });
  }
}

function matches(valor: any, term: string, terms: string[]) {
  return valor[terms[0]].toLowerCase().includes(term.toLowerCase())
  || valor[terms[1]].toLowerCase().includes(term.toLowerCase());
}

@Injectable({ providedIn: 'root' })
export class DataTableService {
  private _loading$ = new BehaviorSubject<boolean>(true);
  private _search$ = new Subject<void>();
  private _dados$ = new BehaviorSubject<any[]>([]);
  private _total$ = new BehaviorSubject<number>(0);

  private _state: State = {
    page: 1,
    pageSize: 4,
    searchTerm: '',
    sortColumn: '',
    sortDirection: ''
  };

  dados: any[];
  termsAccepts: any[];
  constructor(private pipe: DecimalPipe) {
    this._search$.pipe(
      tap(() => this._loading$.next(true)),
      debounceTime(200),
      switchMap(() => this._search()),
      delay(200),
      tap(() => this._loading$.next(false))
    ).subscribe(result => {
      this._dados$.next(result.dados);
      this._total$.next(result.total);
    });
    this._search$.next();
    this.dados = new Array<any>();
    this.termsAccepts = new Array<any>();
  }

  get dados$() { return this._dados$.asObservable(); }
  get total$() { return this._total$.asObservable(); }
  get loading$() { return this._loading$.asObservable(); }
  get page() { return this._state.page; }
  get pageSize() { return this._state.pageSize; }
  get searchTerm() { return this._state.searchTerm; }

  set page(page: number) { this._set({ page }); }
  set pageSize(pageSize: number) { this._set({ pageSize }); }
  set searchTerm(searchTerm: string) { this._set({ searchTerm }); }
  set sortColumn(sortColumn: string) { this._set({ sortColumn }); }
  set sortDirection(sortDirection: SortDirection) { this._set({ sortDirection }); }

  private _set(patch: Partial<State>) {
    Object.assign(this._state, patch);
    this._search$.next();
  }

  private _search(): Observable<SearchResult> {
    const { sortColumn, sortDirection, pageSize, page, searchTerm } = this._state;

    // 1. sort
    let valores = [];
    valores = sort(this.dados, sortColumn, sortDirection);

    // 2. filter
    valores = valores.filter(dados => matches(dados, searchTerm, this.termsAccepts));
    const total = valores.length;

    // 3. paginate
    valores = valores.slice((page - 1) * pageSize, (page - 1) * pageSize + pageSize);
    return of({ dados: valores, total });
  }
}
