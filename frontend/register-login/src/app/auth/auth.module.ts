import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { GenericModule } from './../generic/generic.module';
import { MaterialModule } from './../generic/material.module';
import { LoginPageComponent } from './components/login-page/login-page.component';

@NgModule({
  imports: [
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    GenericModule,
    FormsModule,
    MaterialModule
  ],
  declarations: [LoginPageComponent],
  exports: [LoginPageComponent]
})
export class AuthModule { }
