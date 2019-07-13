import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemNoteCategoryComponent } from './item-note-category.component';

describe('ItemNoteCategoryComponent', () => {
  let component: ItemNoteCategoryComponent;
  let fixture: ComponentFixture<ItemNoteCategoryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ItemNoteCategoryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ItemNoteCategoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
