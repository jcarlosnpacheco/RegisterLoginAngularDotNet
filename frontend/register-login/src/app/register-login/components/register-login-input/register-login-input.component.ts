import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroupDirective, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MessageService } from 'src/app/generic/services/message.service';
import { ValidateFormFieldsService } from 'src/app/generic/services/validate-form-fields.service';

import { RegisterLoginService } from './../../services/register-login.service';

@Component({
  selector: 'app-register-login-input',
  templateUrl: './register-login-input.component.html',
  styleUrls: ['./register-login-input.component.css'],
})
export class RegisterLoginInputComponent implements OnInit {
  @Input() titlePage: string;
  @Input() submitButton: string;
  @Input() registerLoginId: number;
  @Output() submitted = new EventEmitter<any>();

  registerLoginForm: any;
  hide = true;

  constructor(
    private fb: FormBuilder,
    private message: MessageService,
    private validateFormFieldsService: ValidateFormFieldsService,
    private router: Router,
    private registerLogin: RegisterLoginService
  ) {
    this.titlePage = '';
    this.submitButton = '';
    this.registerLoginId = 0;
  }

  ngOnInit() {
    if (this.registerLoginId > 0) {
      this.registerLogin.getById(this.registerLoginId).subscribe((register) => {
        this.registerLoginForm.patchValue(register);
      });
    }

    this.createForm(this.registerLoginId);
  }

  createForm(registerLoginId: number) {
    this.registerLoginForm = this.fb.group({
      id: [registerLoginId],
      loginName: [
        null,
        Validators.compose([Validators.required, Validators.maxLength(50)]),
      ],
      password: [null, Validators.compose([Validators.required])],
      observation: [],
      loginTypeId: [1],
    });
  }

  onSubmit(): void {
    if (this.registerLoginForm.valid) {
      this.submitted.emit(this.registerLoginForm);
    } else {
      this.validateFormFieldsService.validateAllFormFields(
        this.registerLoginForm
      );
      this.message.showWarningMessage('Invalid Form');
    }
  }

  onReset(form: FormGroupDirective): void {
    form.resetForm();
  }

  onCancel(): void {
    this.router.navigate(['/registerLogin']);
  }
}
