import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TrocarSenhaComponent } from './trocar-senha.component';

describe('TrocarSenhaComponent', () => {
  let component: TrocarSenhaComponent;
  let fixture: ComponentFixture<TrocarSenhaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TrocarSenhaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TrocarSenhaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
