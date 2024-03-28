import { TestBed } from '@angular/core/testing';

import { CoronaVaccinesService } from './corona-vaccines.service';

describe('CoronaVaccinesService', () => {
  let service: CoronaVaccinesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CoronaVaccinesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
