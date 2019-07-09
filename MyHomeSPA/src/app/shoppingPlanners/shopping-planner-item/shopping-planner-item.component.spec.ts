import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ShoppingPlannerItemComponent } from './shopping-planner-item.component';

describe('ShoppingPlannerItemComponent', () => {
  let component: ShoppingPlannerItemComponent;
  let fixture: ComponentFixture<ShoppingPlannerItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ShoppingPlannerItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ShoppingPlannerItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
