import { Component, OnInit } from '@angular/core';
import { Dialog } from '@angular/cdk/dialog';
import { RegistrationDialogComponent, RegistrationDialogExitStatus } from '../dialogs/registration-dialog/registration-dialog.component';
import { MatDialog, MatDialogConfig, MatDialogRef } from '@angular/material/dialog';
import { LoginProfileDialogComponent, LoginProfileDialogExitStatus } from '../dialogs/login-profile-dialog/login-profile-dialog.component';
import { LoginDialogComponent, LoginDialogExitState } from '../dialogs/login-dialog/login-dialog.component';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.css']
})
export class MainPageComponent implements OnInit {

  constructor(public dialog: MatDialog) { }

  ngOnInit(): void {
  }

  public onLoginButton() {


    this.showLoginDialog();

  }


  private showRegDialog() {
    const dialogConfig = new MatDialogConfig();

    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;

    dialogConfig.panelClass="reg-dialog";
    const dialogRef = this.dialog.open(RegistrationDialogComponent, dialogConfig);

    dialogRef.afterClosed().subscribe(result => {
        if (result == RegistrationDialogExitStatus.ChoiseLogin) {
          this.showLoginDialog()
        }
        else if (result == RegistrationDialogExitStatus.SuccessRegistrtation)
        {
          this.showLoginDialog()
        }
    })
  }

  private showLoginProfileDialog () {
    const dialogConfig = new MatDialogConfig();

    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;

    dialogConfig.panelClass="login-profile-dialog";
    const dialogRef = this.dialog.open(LoginProfileDialogComponent, dialogConfig);
    dialogRef.afterClosed().subscribe(result => {
      if (result == LoginProfileDialogExitStatus.registration) {
        this.showRegDialog();
      }
    })
  }

  private showLoginDialog () {
    const dialogConfig = new MatDialogConfig();

    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;

    dialogConfig.panelClass="login-dialog";
    const dialogRef = this.dialog.open(LoginDialogComponent, dialogConfig);

    dialogRef.afterClosed().subscribe(result => {
      console.log(result);
      if (result == LoginDialogExitState.choiseReg)
      {
          this.showRegDialog();
      }
    })
  
  }

}
