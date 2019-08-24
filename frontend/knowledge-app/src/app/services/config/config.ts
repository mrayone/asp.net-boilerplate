import { HttpHeaders } from '@angular/common/http';

export const url = 'https://knowledgeback.azurewebsites.net';

export const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
