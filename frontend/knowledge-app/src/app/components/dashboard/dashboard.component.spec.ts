import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DashBoardComponent } from './dashboard.component';
import { MenuComponent } from '../menu/menu.component';
import { RouterTestingModule } from '@angular/router/testing';

describe('DashBoardComponent', () => {
  let component: DashBoardComponent;
  let menuComponent: MenuComponent;
  let fixture: ComponentFixture<DashBoardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DashBoardComponent, MenuComponent ],
      imports: [ RouterTestingModule ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DashBoardComponent);
    component = fixture.componentInstance;
    menuComponent = TestBed.createComponent(MenuComponent).componentInstance;
    fixture.detectChanges();
  });

  it('Deve criar', () => {
    expect(component).toBeTruthy();
    expect(menuComponent).toBeTruthy();
  });
});
