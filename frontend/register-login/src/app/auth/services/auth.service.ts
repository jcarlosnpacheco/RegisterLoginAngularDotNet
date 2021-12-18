import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

import { AuthenticateResult } from '../models/authenticate-result.model';
import { Logon } from '../models/logon.model';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private accessToken = 'access_token';
  private expirationToken = 'expiration_token';
  private urlLogon = `${environment.apiUrl}/Home`;

  constructor(private http: HttpClient) {}

  // Session
  logon(logon: Logon): Observable<AuthenticateResult> {
    return this.http
      .post<AuthenticateResult>(`${this.urlLogon}/login`, logon)
      .pipe(tap((resp) => this.setSession(resp)));
  }

  logoff() {
    this.cleanSession();
  }

  getToken(): string | null {
    return localStorage.getItem(this.accessToken);
  }

  getExpirationToken(): string | null {
    return localStorage.getItem(this.expirationToken);
  }

  hasToken(): boolean {
    return this.getToken() !== null;
  }

  isLoggedIn(): boolean {
    const currentTime = new Date().getTime() / 1000;
    const expiration = this.getExpirationToken()?.toString();

    return expiration == null ? false : expiration > currentTime.toString();
  }

  private setSession(authResult: AuthenticateResult) {
    localStorage.setItem(this.accessToken, authResult.token);
    localStorage.setItem(
      this.expirationToken,
      authResult.expires.toString()
    );

    console.log(this.isLoggedIn());
    console.log(this.hasToken());
    console.log(this.getExpirationToken());

  }

  private cleanSession() {
    localStorage.removeItem(this.accessToken);
    localStorage.removeItem(this.expirationToken);
  }
}
