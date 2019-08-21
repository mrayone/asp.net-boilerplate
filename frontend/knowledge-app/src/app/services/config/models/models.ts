import { HttpParams } from '@angular/common/http';

export class TokenModel {
  access_token: string;
  expires_in: number;
  token_type: string;
  refresh_token: string;
  scope: string;

  constructor() {}
}

export class GrantAcessModel extends HttpParams {
  constructor( username: string, password: string, grant_type: string = 'password',
               client_id: string = 'spa.client', scope: string = 'api offline_access' ) {
    super({
      fromObject: {
        grant_type,
        username,
        password,
        client_id,
        scope,
      }
    });
  }
}
