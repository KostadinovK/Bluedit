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
    return false;
  }

  register(username: string, password: string, confirmPassword: string): Observable<AuthResponse> {
    if (password !== confirmPassword) {
      return;
    }

    return this.http.post<AuthResponse>(this.registerUrl, {username, password, confirmPassword});
  }

  login(username: string, password: string): Observable<AuthResponse> {
    console.log('User logged in...');
    return this.http.post<AuthResponse>(this.registerUrl, {username, password});
  }

  logout() {
  }
}
