import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ShoppingCategoryItemComponent } from './shopping-category-item.component';

describe('ShoppingCategoryItemComponent', () => {
  let component: ShoppingCategoryItemComponent;
  let fixture: ComponentFixture<ShoppingCategoryItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ShoppingCategoryItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ShoppingCategoryItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
