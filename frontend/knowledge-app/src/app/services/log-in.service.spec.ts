import { TestBed, inject } from '@angular/core/testing';

import { LogInService } from './log-in.service';
import {HttpClientModule} from '@angular/common/http';
describe('LogInService', () => {
  let logIn: LogInService;
  beforeEach(() => {
    TestBed.configureTestingModule({
          imports: [
            HttpClientModule
          ],
          providers: [LogInService]
      });

    logIn = TestBed.get(LogInService);
});

  it('should be created', () => {
    const service: LogInService = TestBed.get(LogInService);
    expect(service).toBeTruthy();
  });

  it('#getTokenAcesso deve retornar um observable com o token', (done: DoneFn) => {
      logIn.getTokenAcesso().subscribe(value => {
          expect(value).not.toBeNull();
          expect(value).not.toBeUndefined();
          expect(value.access_token).toString();
          done();
      });
  });
});
