import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, CanActivateChild, Route, Router, RouterStateSnapshot, UrlTree } from "@angular/router";
import { Observable } from "rxjs";
import { AuthService } from "../auth.service";
import { DialogHelper } from "../dialog-helper";


@Injectable()
export class AuthGuard implements CanActivate, CanActivateChild {

    constructor(private authService:AuthService, private router:Router, private dialogHelper: DialogHelper) {

    }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
        if (this.authService.isLoggedIn())
        {
            return true;
        }
        this.dialogHelper.showLoginProfileDialog();
        return false;
    }

    canActivateChild(childRoute: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
        return this.canActivate(childRoute, state)
    }

}