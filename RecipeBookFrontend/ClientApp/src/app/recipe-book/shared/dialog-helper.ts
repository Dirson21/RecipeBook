import { Injectable } from "@angular/core";
import { MatDialog, MatDialogConfig } from "@angular/material/dialog";
import { LoginDialogComponent, LoginDialogExitState } from "../dialogs/login-dialog/login-dialog.component";
import { LoginProfileDialogComponent, LoginProfileDialogExitStatus } from "../dialogs/login-profile-dialog/login-profile-dialog.component";
import { RegistrationDialogComponent, RegistrationDialogExitStatus } from "../dialogs/registration-dialog/registration-dialog.component";

@Injectable()
export class DialogHelper {

  dialogConfig!: MatDialogConfig;

  constructor(private dialog: MatDialog) {
    this.dialogConfig = new MatDialogConfig();
    this.dialogConfig.disableClose = true;
    this.dialogConfig.autoFocus = false;
    this.dialogConfig.restoreFocus = false;
    
    

  }

  public showRegDialog() {

    this.dialogConfig.panelClass = "reg-dialog";
    const dialogRef = this.dialog.open(RegistrationDialogComponent, this.dialogConfig);

    dialogRef.afterClosed().subscribe(result => {
      if (result == RegistrationDialogExitStatus.ChoiseLogin) {
        this.showLoginDialog()
      }
      else if (result == RegistrationDialogExitStatus.SuccessRegistrtation) {
        this.showLoginDialog()
      }
    })
  }

  public showLoginProfileDialog() {

    this.dialogConfig.panelClass = "login-profile-dialog";
    const dialogRef = this.dialog.open(LoginProfileDialogComponent, this.dialogConfig);
    dialogRef.afterClosed().subscribe(result => {
      if (result == LoginProfileDialogExitStatus.registration) {
        this.showRegDialog();
      }
      if (result == LoginProfileDialogExitStatus.login) {
        this.showLoginDialog();
      }
    })
  }

  public showLoginDialog() {
    this.dialogConfig.panelClass = "login-dialog";
    const dialogRef = this.dialog.open(LoginDialogComponent, this.dialogConfig);

    dialogRef.afterClosed().subscribe(result => {
      console.log(result);
      if (result == LoginDialogExitState.choiceReg) {
        this.showRegDialog();
      }
    })

  }
}