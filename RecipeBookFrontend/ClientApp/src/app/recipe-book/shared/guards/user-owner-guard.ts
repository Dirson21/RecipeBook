import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, CanActivateChild, Route, Router, RouterStateSnapshot, UrlTree } from "@angular/router";
import { Observable } from "rxjs";
import { AuthService } from "../auth.service";
import { DialogHelper } from "../dialog-helper";


@Injectable()
export class UserOwnerGuard implements CanActivate, CanActivateChild {

    constructor(private authService:AuthService, private router:Router, private dialogHelper: DialogHelper) {

    }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
        
        const userId: string|undefined = route.params["id"]
        console.log(userId);
        if (!userId)
        {
            return false;
        }

        if (this.authService.isLoggedIn() && this.authService.isLoggedUser(userId))
        {
            return true;
        }
        return false;
    }

    canActivateChild(childRoute: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
        return this.canActivate(childRoute, state)
    }

}