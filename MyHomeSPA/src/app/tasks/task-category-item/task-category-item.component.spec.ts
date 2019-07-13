import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TaskCategoryItemComponent } from './task-category-item.component';

describe('TaskCategoryItemComponent', () => {
  let component: TaskCategoryItemComponent;
  let fixture: ComponentFixture<TaskCategoryItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TaskCategoryItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TaskCategoryItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
