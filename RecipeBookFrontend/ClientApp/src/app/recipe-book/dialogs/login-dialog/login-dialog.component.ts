import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { AuthService } from '../../shared/auth.service';
import { ILoginForm } from '../../shared/forms/loginForm.interface';
import { UserAccountService } from '../../shared/user-account.service';


export enum LoginDialogExitState {
    successLogin = 1,
    choiceReg,
    cancel
}

@Component({
  selector: 'app-login-dialog',
  templateUrl: './login-dialog.component.html',
  styleUrls: ['./login-dialog.component.css']
})
export class LoginDialogComponent implements OnInit {

  constructor(private fb: FormBuilder,
    private dialogRef: MatDialogRef<LoginDialogComponent>,
    private userAccountService: UserAccountService,
    private authService: AuthService) {

  }

  form!:FormGroup

  ngOnInit(): void {
    this.form = this.fb.group({
      login: ['', Validators.required],
      password: ['', Validators.required]
    })
  }

  public login() {
      if (this.form.invalid) return;
      
      const loginForm: ILoginForm = Object.assign({}, this.form.value)

      this.userAccountService.login(loginForm).subscribe(result => {
        console.log(result);
        this.authService.setSession(result);
        console.log(this.authService.isLoggedIn());
        this.dialogRef.close(LoginDialogExitState.successLogin)
      })

  }

  public cancel() {
      this.dialogRef.close(LoginDialogExitState.cancel)
  }

  public choiceReg() {
      this.dialogRef.close(LoginDialogExitState.choiceReg);
  }

}
