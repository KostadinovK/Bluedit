import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth/AuthService';
import { Router } from '@angular/router';

@Component({
  selector: 'app-shared-header',
  templateUrl: './shared-header.component.html',
  styleUrls: ['./shared-header.component.scss']
})
export class SharedHeaderComponent implements OnInit {
  constructor(private authService: AuthService, private router: Router) { }

  get isLoggedIn(): boolean {
    return this.authService.isLoggedIn();
  }

  get username(): string {
    return this.authService.getUsername();
  }

  ngOnInit(): void {}

  async logout() {
    this.authService.logout();
    await this.router.navigate(['/']);
  }
}
