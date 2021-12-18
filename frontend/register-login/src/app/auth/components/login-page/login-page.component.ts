import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MessageService } from 'src/app/generic/services/message.service';

import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css'],
})
export class LoginPageComponent implements OnInit {
  hide = true;
  errorMessage = '';

  loginForm = this.fb.group({
    username: ['', Validators.required],
    password: ['', Validators.required],
  });

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router,
    private messageService: MessageService
  ) {}

  ngOnInit(): void {
    if (this.authService.hasToken() && this.authService.isLoggedIn()) {
      this.router.navigate(['/home']);
    }
  }

  onSignIn(): void {
    if (this.loginForm.valid) {
      this.authService.logon(this.loginForm.value).subscribe(
        () => {
          this.router.navigate(['/home']);
        },
        (error) => {
          this.messageService.showErrorMessage('User not authenticated');
          throw error;
        }
      );
    }
  }
}
