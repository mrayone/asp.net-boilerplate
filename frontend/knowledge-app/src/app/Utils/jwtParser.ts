import * as jwt_decode from 'jwt-decode';

export function jwtParser(token: string): object {
      try {
          return jwt_decode(token);
      } catch (Error) {
          return null;
      }
}
