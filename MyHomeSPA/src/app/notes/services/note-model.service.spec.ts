import { TestBed } from '@angular/core/testing';

import { NoteModelService } from './note-model.service';

describe('NoteModelService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: NoteModelService = TestBed.get(NoteModelService);
    expect(service).toBeTruthy();
  });
});
