import { HttpHeaders } from '@angular/common/http';

export const url = 'http://knowledgeback.azurewebsites.net';

export const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
