import { TestBed } from '@angular/core/testing';

import { ErrosService } from './erros.service';

describe('ErrosService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ErrosService = TestBed.get(ErrosService);
    expect(service).toBeTruthy();
  });
});
