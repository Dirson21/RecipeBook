import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';


export enum LoginProfileDialogExitStatus {
  login = 1,
  registration,
  close
}

@Component({
  selector: 'app-login-profile-dialog',
  templateUrl: './login-profile-dialog.component.html',
  styleUrls: ['./login-profile-dialog.component.css']
})
export class LoginProfileDialogComponent implements OnInit {

  constructor(private dialogRef: MatDialogRef<LoginProfileDialogComponent>) { }

  ngOnInit(): void {
  }

  public closeDialog() {
    this.dialogRef.close(LoginProfileDialogExitStatus.close)
  }

  public choiseLogin() {
    this.dialogRef.close(LoginProfileDialogExitStatus.login)
  }

  public choiseReg() {
    this.dialogRef.close(LoginProfileDialogExitStatus.registration)
  }

}
