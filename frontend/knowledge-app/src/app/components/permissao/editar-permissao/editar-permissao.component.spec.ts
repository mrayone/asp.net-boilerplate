import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditarPermissaoComponent } from './editar-permissao.component';

describe('EditarPermissaoComponent', () => {
  let component: EditarPermissaoComponent;
  let fixture: ComponentFixture<EditarPermissaoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditarPermissaoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditarPermissaoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
