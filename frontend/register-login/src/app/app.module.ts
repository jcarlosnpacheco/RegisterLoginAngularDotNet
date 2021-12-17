import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FlexLayoutModule } from '@angular/flex-layout';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthModule } from './auth/auth.module';
import { GenericModule } from './generic/generic.module';
import { AuthInterceptor } from './generic/interceptors/auth.interceptor';
import { MaterialModule } from './generic/material.module';

@NgModule({
  declarations: [AppComponent],
  imports: [
    FlexLayoutModule,
    AppRoutingModule,
    AuthModule,
    BrowserModule,
    GenericModule,
    MaterialModule,
    RouterModule,
    BrowserAnimationsModule,
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true }],
  bootstrap: [AppComponent],
})
export class AppModule {}
