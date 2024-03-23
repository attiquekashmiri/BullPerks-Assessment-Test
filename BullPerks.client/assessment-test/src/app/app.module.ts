import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { FormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { InfoComponent } from './components/info/info.component';
import { UpdateComponent } from './components/update/update.component';
import { TokenInterceptor } from './_interceptors/auth.interceptor';
import { NavbarComponent } from './components/navbar/navbar.component';
import { CommonModule } from '@angular/common';
import { WeiToEtherPipe } from './pipes/wei-to-ether.pipe';
import { UtcToLocalDatePipe } from './pipes/utc-to-local-date.pipe';

@NgModule({
  declarations: [AppComponent, LoginComponent, InfoComponent, UpdateComponent, NavbarComponent, WeiToEtherPipe, UtcToLocalDatePipe],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    CommonModule
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: TokenInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent],
})
export class AppModule {}
