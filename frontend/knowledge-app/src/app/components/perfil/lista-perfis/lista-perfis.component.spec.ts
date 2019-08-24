import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaPerfisComponent } from './lista-perfis.component';

describe('ListarPerfisComponent', () => {
  let component: ListaPerfisComponent;
  let fixture: ComponentFixture<ListaPerfisComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListaPerfisComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListaPerfisComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
