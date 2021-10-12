import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GuestPageComponent } from './guest-page/guest-page.component';
import { LoginComponent } from './user/login/login.component';
import { RegisterComponent } from './user/register/register.component';


const routes: Routes = [
  { path: '', component: GuestPageComponent},
  { path: 'login', component: LoginComponent},
  { path: 'register', component: RegisterComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
