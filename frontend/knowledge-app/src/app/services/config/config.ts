import { HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';

export const url = environment.apiUrl;

export const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
