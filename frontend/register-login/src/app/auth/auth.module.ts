import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { LoginPageComponent } from './components/login-page/login-page.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [LoginPageComponent]
})
export class AuthModule { }
