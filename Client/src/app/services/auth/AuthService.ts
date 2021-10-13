import { IAuthService } from './IAuthService';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';

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

  register(username: string, password: string, confirmPassword: string) {
    if (password !== confirmPassword) {
      return;
    }
    const data = this.http.post(this.registerUrl, {username, password, confirmPassword});
    data.subscribe(v => console.log(v));
    console.log('User registered...');
  }

  login(username: string, password: string) {
    console.log('User logged in...');
  }

  logout() {
  }
}
