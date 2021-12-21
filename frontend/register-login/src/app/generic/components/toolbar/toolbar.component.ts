import { Component, EventEmitter, Output } from '@angular/core';
import { AuthService } from 'src/app/auth/services/auth.service';


@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.css'],
})
export class ToolbarComponent {
  @Output() openCloseMenu = new EventEmitter();

  isLogged$ = this.authService.logged();

  constructor(private authService: AuthService) {
  }

  logoff() {
    this.authService.logoff();
    window.location.reload();
  }
}
