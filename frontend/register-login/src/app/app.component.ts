import { Component, OnInit } from '@angular/core';

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

  constructor(
    public loaderService: LoaderService

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
