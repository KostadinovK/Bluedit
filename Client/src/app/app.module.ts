import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { GuestPageComponent } from './guest-page/guest-page.component';
import { SharedModule } from './shared/shared.module';
import { UserModule } from './user/user.module';
import { AuthInterceptor } from './guards-and-interceptors/AuthInterceptor';
import { AuthenticationGuard } from './guards-and-interceptors/AuthenticationGuard';

@NgModule({
  declarations: [
    AppComponent,
    GuestPageComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    SharedModule,
    UserModule,
  ],
  providers: [
    AuthenticationGuard,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true,
    },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
