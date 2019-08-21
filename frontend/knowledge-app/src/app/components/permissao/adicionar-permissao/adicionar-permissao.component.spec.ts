import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdicionarPermissaoComponent } from './adicionar-permissao.component';

describe('AdicionarPermissaoComponent', () => {
  let component: AdicionarPermissaoComponent;
  let fixture: ComponentFixture<AdicionarPermissaoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdicionarPermissaoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdicionarPermissaoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
