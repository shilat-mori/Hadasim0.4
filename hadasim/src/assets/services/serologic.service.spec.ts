import { TestBed } from '@angular/core/testing';

import { SerologicService } from './serologic.service';

describe('SerologicService', () => {
  let service: SerologicService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SerologicService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
