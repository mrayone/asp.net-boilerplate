import { HttpHeaders } from '@angular/common/http';

export const url = 'http://localhost:5001';

export const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
