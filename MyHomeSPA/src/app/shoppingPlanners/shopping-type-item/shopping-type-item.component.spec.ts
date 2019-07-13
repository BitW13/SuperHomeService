import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ShoppingTypeItemComponent } from './shopping-type-item.component';

describe('ShoppingTypeItemComponent', () => {
  let component: ShoppingTypeItemComponent;
  let fixture: ComponentFixture<ShoppingTypeItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ShoppingTypeItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ShoppingTypeItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
