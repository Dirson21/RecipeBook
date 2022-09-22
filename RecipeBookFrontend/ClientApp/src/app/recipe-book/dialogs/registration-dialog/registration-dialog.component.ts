import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators, AbstractControlOptions, ValidationErrors, ValidatorFn, AbstractControlDirective, FormControl } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { IRegistrationForm } from '../../shared/forms/registrationForm.interface';
import { UserAccountService } from '../../shared/user-account.service';


export const passwordConfirmingValidator: ValidatorFn = (control: AbstractControl):
  ValidationErrors | null => {
  const password = control.get("password");
  const confirmPassword = control.get("confirmPassword");
  if (password?.value == confirmPassword?.value) {
    return null;
  }
  return { confirmError: true }
}


export enum RegistrationDialogExitStatus {
  SuccessRegistrtation = 1,
  ChoiseLogin,
  CloseDialog
}

@Component({
  selector: 'app-registration-dialog',
  templateUrl: './registration-dialog.component.html',
  styleUrls: ['./registration-dialog.component.css']
})
export class RegistrationDialogComponent implements OnInit {

  constructor(private fb: FormBuilder,
    private dialogRef: MatDialogRef<RegistrationDialogComponent>,
    private userAccountService: UserAccountService) { }

  form!: FormGroup

  error: string = "";

  ngOnInit(): void {
    const opt: AbstractControlOptions = {
      validators: passwordConfirmingValidator
    }


    this.form = this.fb.group({
      login: ["", Validators.required],
      name: ["", Validators.required],

      password: ["", [Validators.required, Validators.minLength(8)]],
      confirmPassword: ["", [Validators.required]]
    }, opt)


  }

  public registrationUser() {

    if (this.form.invalid) return;


    let registrationForm: IRegistrationForm;

    registrationForm = Object.assign({}, this.form.value);

    

    console.log(registrationForm);
    this.userAccountService.registration(registrationForm).subscribe({
      next: result => {
        console.log(result)
        this.dialogRef.close(RegistrationDialogExitStatus.SuccessRegistrtation);
      },
      error: error => {
        if (error.error == "DuplicateUserName") {
         this.loginControl.setErrors({
            notUnique: true
          })
        }
        

      }
    })

  }

  public closeDialog() {
    this.dialogRef.close(RegistrationDialogExitStatus.CloseDialog);
  }

  public choiseLogin() {
    this.dialogRef.close(RegistrationDialogExitStatus.ChoiseLogin)
  }

  get loginControl(): AbstractControl {
    return this.form.get("login")!;
  }

}




