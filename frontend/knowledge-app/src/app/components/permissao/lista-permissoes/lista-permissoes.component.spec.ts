import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaPermissoesComponent } from './lista-permissoes.component';

describe('ListaPermissoesComponent', () => {
  let component: ListaPermissoesComponent;
  let fixture: ComponentFixture<ListaPermissoesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListaPermissoesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListaPermissoesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
