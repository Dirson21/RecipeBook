import { IRecipe } from "./recipe.interface";
import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IRegistrationForm } from "./forms/registrationForm.interface";
import { ILoginForm } from "./forms/loginForm.interface";
import { ITokenView } from "./forms/token-view.interface";
import { JwtHelperService } from "@auth0/angular-jwt";
import * as moment from "moment";


export class AuthService {

    jwtHelper!: JwtHelperService;

    constructor() {
        this.jwtHelper = new JwtHelperService();
    }

    public setSession(authResult: ITokenView) {
        localStorage.setItem("id_token", authResult.jwtToken)
        localStorage.setItem("id_user", authResult.id)
        localStorage.setItem("login", authResult.login)


    }

    public getLogin(): string | null {
        return localStorage.getItem("login");
    }

    public logout() {
        localStorage.removeItem("id_token");
        localStorage.removeItem("id_user");
        localStorage.removeItem("login")
    }

    public isLoggedIn() {
        const jwtToken = localStorage.getItem("id_token");

        if (jwtToken) {
            const currentDate = new Date()
            const tokenDate = this.jwtHelper.getTokenExpirationDate(jwtToken);
            if (tokenDate) {
                return currentDate.getTime() < tokenDate.getTime()
            }

        }
        return false

    }
}