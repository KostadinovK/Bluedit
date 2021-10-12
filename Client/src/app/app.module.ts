import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { GuestPageComponent } from './guest-page/guest-page.component';
import { SharedModule } from './shared/shared.module';
import { UserModule } from './user/user.module';

@NgModule({
  declarations: [
    AppComponent,
    GuestPageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    SharedModule,
    UserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
