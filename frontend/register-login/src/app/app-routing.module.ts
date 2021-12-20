import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LoginComponent } from './auth/components/login/login.component';
import { LogoutComponent } from './auth/components/logout/logout.component';
import { PageNotFoundComponent } from './generic/components/page-not-found/page-not-found.component';
import { RegisterLoginGridComponent } from './register-login/components/register-login-grid/register-login-grid.component';

const routes: Routes = [
  { path: '', component: LoginComponent},
  { path: 'logout', component: LogoutComponent },
  { path: 'registerLogin', component: RegisterLoginGridComponent },
  { path: '**', pathMatch: 'full', component: PageNotFoundComponent },
];

/*{
    path: 'registerLogin',
    loadChildren: () =>
      import('./register-login/register-login.module').then(
        (m) => m.RegisterLoginModule
      ),
  },*/

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
