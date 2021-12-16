import { NgModule } from '@angular/core';
import { FlexLayoutModule } from '@angular/flex-layout';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthModule } from './auth/auth.module';
import { GenericModule } from './generic/generic.module';
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
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
