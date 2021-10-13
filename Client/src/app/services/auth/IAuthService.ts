export interface IAuthService {

  isLoggedIn(): boolean;

  login(username: string, password: string);

  register(username: string, password: string, confirmPassword: string);

  logout();
}
