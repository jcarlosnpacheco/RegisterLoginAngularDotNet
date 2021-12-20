import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { GenericModule } from './../generic/generic.module';
import { RegisterLoginGridComponent } from './components/register-login-grid/register-login-grid.component';

@NgModule({
  imports: [CommonModule, GenericModule, ReactiveFormsModule, RouterModule],
  declarations: [RegisterLoginGridComponent],
})
export class RegisterLoginModule {}
