import { IRecipe } from "./recipe.interface";
import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IRegistrationForm } from "./forms/registrationForm.interface";
import { ILoginForm } from "./forms/loginForm.interface";
import { ITokenView } from "./forms/token-view.interface";
import { JwtHelperService } from "@auth0/angular-jwt";
import * as moment from "moment";


@Injectable()
export class UserAccountService {
    private readonly apiUrl:string = "http://localhost:4200/api/user"

    jwtHelper!:JwtHelperService;

    constructor (private readonly httpClient: HttpClient) {
        this.jwtHelper = new JwtHelperService();
    }

    public registration(registrationForm:IRegistrationForm): Observable<string> {
        return this.httpClient.post<string>(`${this.apiUrl}`, registrationForm);
    }

    public login(loginForm: ILoginForm): Observable <ITokenView> {
        return this.httpClient.post<ITokenView>(`${this.apiUrl}/login`, loginForm)
    }
    
}