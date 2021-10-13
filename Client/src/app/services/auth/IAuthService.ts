import {Observable} from 'rxjs';
import {AuthResponse} from '../../models/auth/AuthResponse';

export interface IAuthService {

  isLoggedIn(): boolean;

  login(username: string, password: string): Observable<AuthResponse>;

  register(username: string, password: string, confirmPassword: string): Observable<AuthResponse>;

  logout();

  saveAuthInfo(authInfo: AuthResponse);

  getToken(): string;

  getUsername(): string;
}
