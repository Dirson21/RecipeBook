import { IRecipe } from "./interfaces/recipe.interface";
import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IRegistrationForm } from "./interfaces/registrationForm.interface";
import { ILoginForm } from "./interfaces/loginForm.interface";
import { ITokenView } from "./interfaces/token-view.interface";
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
        localStorage.setItem("name", authResult.name)


    }

    public getLogin(): string | null {
        return localStorage.getItem("login");
    }

    public getName(): string | null {
        return localStorage.getItem("name");
    }
    
    public updateName(name:string) {
        localStorage.setItem("name", name);
    }

    public updateName(name: string) {
        localStorage.setItem("name", name);
    }

    public logout() {
        localStorage.removeItem("id_token");
        localStorage.removeItem("id_user");
        localStorage.removeItem("login")
        localStorage.removeItem("name")
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

    public isLoggedUser(userId: string) {
        const jwtToken = localStorage.getItem("id_token");

        if (jwtToken && this.isLoggedIn()) {
            const jwtDecode = this.jwtHelper.decodeToken(jwtToken)
            return jwtDecode["nameid"] == userId;
        }
        return false;

    }

    public getUserId(): string {
        const userId = localStorage.getItem("id_user");
        if (userId) {
            return userId
        }
        return "";

    }
}