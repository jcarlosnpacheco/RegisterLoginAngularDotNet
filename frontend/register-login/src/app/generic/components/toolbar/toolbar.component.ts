import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AuthService } from 'src/app/auth/services/auth.service';

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.css'],
})
export class ToolbarComponent implements OnInit {
  @Output() openCloseMenu = new EventEmitter();

  isLogged$ = this.authService.isLogged$;

  constructor(private authService: AuthService) {}

  ngOnInit(): void {}
}
