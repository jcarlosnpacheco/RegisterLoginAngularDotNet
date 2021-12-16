import { NgModule } from '@angular/core';
import { FlexLayoutModule } from '@angular/flex-layout';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { AuthModule } from './auth/auth.module';

@NgModule({
  declarations: [AppComponent],
  imports: [FlexLayoutModule, AuthModule, BrowserModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
