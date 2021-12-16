import { Component } from '@angular/core';

import { MenuItem } from './generic/models/MenuItem';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'Register Login';
  menuItems: MenuItem[] = [];
  menuOpened = false;

  openCloseMenu(): void {
    this.menuOpened = !this.menuOpened;
  }
  private setMenuItems(): void {
    this.menuItems = [
      {
        icon: 'drag_indicator',
        routerLink: 'loginType',
        tooltip: 'click to create your Login Type',
      },
      {
        icon: 'drag_indicator',
        routerLink: 'registerLogin',
        tooltip: 'click to create your Register Login',
      },
    ];
  }
}
