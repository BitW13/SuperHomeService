import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FormNoteCategoryComponent } from './form-note-category.component';

describe('FormNoteCategoryComponent', () => {
  let component: FormNoteCategoryComponent;
  let fixture: ComponentFixture<FormNoteCategoryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FormNoteCategoryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FormNoteCategoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
