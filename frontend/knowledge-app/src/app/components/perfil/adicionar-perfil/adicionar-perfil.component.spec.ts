import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdicionarPerfilComponent } from './adicionar-perfil.component';

describe('AdicionarPerfilComponent', () => {
  let component: AdicionarPerfilComponent;
  let fixture: ComponentFixture<AdicionarPerfilComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdicionarPerfilComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdicionarPerfilComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
