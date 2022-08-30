import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../shared/auth.service';
import { DialogHelper } from '../shared/dialog-helper';
import { IUserAccount } from '../shared/user-account.interface';
import { UserAccountService } from '../shared/user-account.service';


@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor(private userAccountService:UserAccountService,
     public authService: AuthService,
      private dialogHelper: DialogHelper,
      private router: Router) { }

  ngOnInit(): void {
  }

  public login() {
    this.dialogHelper.showLoginDialog();
  }

  public logout() {
    this.router.navigate(["/"]);
    this.authService.logout();
  }

}
