import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NoteCategoryAddComponent } from './note-category-add.component';

describe('NoteCategoryAddComponent', () => {
  let component: NoteCategoryAddComponent;
  let fixture: ComponentFixture<NoteCategoryAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NoteCategoryAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NoteCategoryAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
