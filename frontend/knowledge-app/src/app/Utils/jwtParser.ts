export function jwtParser(token: string): object {
    const base64 = token.split('.')[1];

    return JSON.parse(window.atob(base64));
}
