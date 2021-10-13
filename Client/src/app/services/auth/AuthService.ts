/* tslint:disable:no-trailing-whitespace */
import { IAuthService } from './IAuthService';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import {Observable} from 'rxjs';
import {AuthResponse} from '../../models/auth/AuthResponse';

@Injectable({
  providedIn: 'root'
})
export class AuthService implements IAuthService {

  private registerUrl = `${environment.apiUrl}/Identity/Register`;
  private loginUrl = `${environment.apiUrl}/Identity/Login`;

  constructor(private http: HttpClient) {}

  isLoggedIn(): boolean {
    const token = this.getToken();

    return !!token;
  }

  register(username: string, password: string, confirmPassword: string): Observable<AuthResponse> {
    if (password !== confirmPassword) {
      return;
    }

    return this.http.post<AuthResponse>(this.registerUrl, {username, password, confirmPassword});
  }

  login(username: string, password: string): Observable<AuthResponse> {
    return this.http.post<AuthResponse>(this.loginUrl, {username, password});
  }

  logout() {
    localStorage.clear();
  }

  getToken(): string {
    return localStorage.getItem('token');
  }

  getUsername(): string {
    return localStorage.getItem('username');
  }

  saveAuthInfo(authInfo: AuthResponse) {
    localStorage.setItem('username', authInfo.username);
    localStorage.setItem('token', authInfo.token);
    localStorage.setItem('userId', authInfo.id);
    localStorage.setItem('isAdmin', authInfo.isAdmin.toString());
  }
}
