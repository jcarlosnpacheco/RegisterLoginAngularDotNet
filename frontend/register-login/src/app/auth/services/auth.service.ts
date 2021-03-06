import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import jwt_decode from 'jwt-decode';
import { BehaviorSubject, Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

import { AuthenticateResult } from '../models/authenticate-result.model';
import { Logon } from '../models/logon.model';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private loggedState = new BehaviorSubject<boolean>(false);
  private accessToken = 'access_token';
  private urlLogon = `${environment.apiUrl}/Home`;

  constructor(private http: HttpClient) {

  }

  logged() {
    this.loggedState.next(this.hasToken());
    return this.loggedState.asObservable();
  }

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

  getExpiration(): any {
    const tokenDecoded = this.getTokenDecoded();

    if (tokenDecoded === null) {
      return null;
    }

    return tokenDecoded.exp;
  }

  hasToken(): boolean {
    return this.getToken() !== null;
  }

  /*isLoggedIn(): boolean {
    const currentTime = new Date().getTime() /1000;
    const expiration = this.getExpiration();

    if (expiration === null) return false;

    return currentTime > expiration;
  }*/

  getTokenDecoded(): any {
    const token = this.getToken();

    if (token) {
      return jwt_decode(token);
    }

    return null;
  }

  private setSession(authResult: AuthenticateResult) {
    localStorage.clear();
    localStorage.setItem(this.accessToken, authResult.token);
    this.loggedState.next(this.hasToken());
  }

  private cleanSession() {
    localStorage.removeItem(this.accessToken);
    this.loggedState.next(this.hasToken());
  }
}
