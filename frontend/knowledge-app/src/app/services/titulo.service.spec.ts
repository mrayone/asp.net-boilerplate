import { TestBed } from '@angular/core/testing';

import { TituloService } from './titulo.service';

describe('TituloService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: TituloService = TestBed.get(TituloService);
    expect(service).toBeTruthy();
  });
});
