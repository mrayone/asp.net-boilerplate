import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListarPerfisComponent } from './listar-perfis.component';

describe('ListarPerfisComponent', () => {
  let component: ListarPerfisComponent;
  let fixture: ComponentFixture<ListarPerfisComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListarPerfisComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListarPerfisComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
