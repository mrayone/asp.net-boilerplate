import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DetalhesPermissaoComponent } from './detalhes-permissao.component';

describe('DetalhesPermissaoComponent', () => {
  let component: DetalhesPermissaoComponent;
  let fixture: ComponentFixture<DetalhesPermissaoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetalhesPermissaoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DetalhesPermissaoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
