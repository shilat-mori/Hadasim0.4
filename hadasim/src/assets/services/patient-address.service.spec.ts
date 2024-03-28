import { TestBed } from '@angular/core/testing';

import { PatientAddressService } from './patient-address.service';

describe('PatientAddressService', () => {
  let service: PatientAddressService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PatientAddressService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
