import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MessageService } from 'src/app/generic/services/message.service';

import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
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
    if (this.authService.hasToken()) {
      this.router.navigate(['/registerLogin']);
    }
  }

  onSignIn(): void {
    if (this.loginForm.valid) {
      this.authService.logon(this.loginForm.value).subscribe(
        () => {
          this.router.navigate(['/registerLogin']);
        },
        (error) => {
          this.messageService.showErrorMessage('User not authenticated');
          throw error;
        }
      );
    }
  }
}
