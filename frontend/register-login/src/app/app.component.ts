import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/auth/services/auth.service';

import { MenuItem } from './generic/models/MenuItem';
import { LoaderService } from './generic/services/loader.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  menuItems: MenuItem[] = [];
  menuOpened = false;
  isLogged$ = this.authService.isLogged$;

  constructor(
    public loaderService: LoaderService,
    private authService: AuthService
  ) {}

  ngOnInit(): void {
    this.setMenuItems();
  }

  openCloseMenu(): void {
    this.menuOpened = !this.menuOpened;
  }

  private setMenuItems(): void {
    this.menuItems = [
      {
        icon: 'drag_indicator',
        routerLink: 'registerLogin',
        tooltip: 'Register Login',
      },
      {
        icon: 'logout',
        routerLink: 'logout',
        tooltip: 'Logout',
      },
    ];
  }
}
