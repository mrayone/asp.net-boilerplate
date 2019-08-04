import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CardRoundedComponent } from './card-rounded.component';

describe('CardRoundedComponent', () => {
  let component: CardRoundedComponent;
  let fixture: ComponentFixture<CardRoundedComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CardRoundedComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CardRoundedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
