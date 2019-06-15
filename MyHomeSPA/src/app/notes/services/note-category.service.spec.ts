import { TestBed } from '@angular/core/testing';

import { NoteCategoryService } from './note-category.service';

describe('NoteCategoryService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: NoteCategoryService = TestBed.get(NoteCategoryService);
    expect(service).toBeTruthy();
  });
});
