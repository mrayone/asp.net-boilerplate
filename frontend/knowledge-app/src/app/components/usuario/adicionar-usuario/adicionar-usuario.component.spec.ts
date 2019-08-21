import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdicionarUsuarioComponent } from './adicionar-usuario.component';

describe('AdicionarUsuarioComponent', () => {
  let component: AdicionarUsuarioComponent;
  let fixture: ComponentFixture<AdicionarUsuarioComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdicionarUsuarioComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdicionarUsuarioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
