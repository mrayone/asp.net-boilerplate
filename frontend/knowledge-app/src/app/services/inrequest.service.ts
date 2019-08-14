import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InrequestService {

  private inRequest = false;
  constructor() {
  }

  startRequest() {
    this.inRequest = true;
  }

  stopRequest() {
    this.inRequest = false;
  }

  get InRequest() {
    return this.inRequest;
  }
}
