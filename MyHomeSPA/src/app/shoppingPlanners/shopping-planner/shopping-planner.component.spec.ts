import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ShoppingPlannerComponent } from './shopping-planner.component';

describe('ShoppingPlannerComponent', () => {
  let component: ShoppingPlannerComponent;
  let fixture: ComponentFixture<ShoppingPlannerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ShoppingPlannerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ShoppingPlannerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
