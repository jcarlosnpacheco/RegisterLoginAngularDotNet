import { AfterViewInit, Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/auth/services/auth.service';

import { MenuItem } from './generic/models/MenuItem';
import { LoaderService } from './generic/services/loader.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements AfterViewInit {
  menuItems: MenuItem[] = [];
  menuOpened = false;
  isLogged$ = this.authService.logged();

  constructor(
    public loaderService: LoaderService,
    private authService: AuthService,
    private router: Router
  ) {}

  ngAfterViewInit(): void {


    this.getCredentials();
  }

  openCloseMenu(): void {
    this.menuOpened = !this.menuOpened;
  }

  private getCredentials(): void {
    if (this.authService.hasToken()) {
      //this.setMenuItems();
    } else {
      this.router.navigate(['']);
    }
  }

  /*private setMenuItems(): void {
    this.menuItems = [
      {
        icon: 'drag_indicator',
        routerLink: 'registerLogin',
        tooltip: 'Register Login',
      }
    ];
  }*/
}
