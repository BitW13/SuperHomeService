import { TestBed } from '@angular/core/testing';

import { TypeOfPurchaseService } from './type-of-purchase.service';

describe('TypeOfPurchaseService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: TypeOfPurchaseService = TestBed.get(TypeOfPurchaseService);
    expect(service).toBeTruthy();
  });
});
