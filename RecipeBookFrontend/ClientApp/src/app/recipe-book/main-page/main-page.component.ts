import { Component, OnInit } from '@angular/core';
import { Dialog } from '@angular/cdk/dialog';
import { RegistrationDialogComponent, RegistrationDialogExitStatus } from '../dialogs/registration-dialog/registration-dialog.component';
import { MatDialog, MatDialogConfig, MatDialogRef } from '@angular/material/dialog';
import { LoginProfileDialogComponent, LoginProfileDialogExitStatus } from '../dialogs/login-profile-dialog/login-profile-dialog.component';
import { LoginDialogComponent, LoginDialogExitState } from '../dialogs/login-dialog/login-dialog.component';
import { DialogHelper } from '../shared/dialog-helper';
import { AuthService } from '../shared/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.css']
})
export class MainPageComponent implements OnInit {

  constructor(public dialogHelper: DialogHelper, public authService: AuthService, private router:Router) { }

  ngOnInit(): void {
  
  }

  public onLoginButton() {


    this.dialogHelper.showLoginDialog();

  }

}
