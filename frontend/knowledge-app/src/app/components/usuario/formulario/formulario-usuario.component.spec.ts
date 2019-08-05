import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FormularioUsuarioComponent } from './formulario-usuario.component';

describe('FormularioUsuarioComponent', () => {
  let component: FormularioUsuarioComponent;
  let fixture: ComponentFixture<FormularioUsuarioComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FormularioUsuarioComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FormularioUsuarioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
