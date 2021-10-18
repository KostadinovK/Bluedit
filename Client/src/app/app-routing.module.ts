import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './user/login/login.component';
import { RegisterComponent } from './user/register/register.component';
import { HomePageComponent } from './home-page/home-page.component';
import { CreateCommunityComponent } from './community/create-community/create-community.component';
import { AuthenticationGuard } from './guards-and-interceptors/AuthenticationGuard';
import { CommunityDetailsComponent } from './community/community-details/community-details.component';

const routes: Routes = [
  { path: '', component: HomePageComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'community/create', component: CreateCommunityComponent, canActivate: [AuthenticationGuard] },
  { path: 'community/:id', component: CommunityDetailsComponent, canActivate: [AuthenticationGuard] },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
