import { HttpHeaders } from '@angular/common/http';

export const url = 'http://localhost:5001';

export let httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  params: null
};
