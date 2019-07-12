import { TestBed } from '@angular/core/testing';

import { ShoppingCategoryService } from './shopping-category.service';

describe('ShoppingCategoryService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ShoppingCategoryService = TestBed.get(ShoppingCategoryService);
    expect(service).toBeTruthy();
  });
});
