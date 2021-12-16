import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LoginPageComponent } from './auth/login-page/login-page.component';
import { PageNotFoundComponent } from './generic/page-not-found/page-not-found.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  { path: '', component: LoginPageComponent, pathMatch: 'full' },
  { path: 'home', component: HomeComponent, pathMatch: 'full' },
  {
    path: 'loginType',
    loadChildren: () =>
      import('./login-type/login-type.module').then(
        (m) => m.LoginTypeModule
      ),
  },
  {
    path: 'registerLogin',
    loadChildren: () =>
      import('./register-login/register-login.module').then(
        (m) => m.RegisterLoginModule
      ),
  },
  { path: '**', pathMatch: 'full', component: PageNotFoundComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
