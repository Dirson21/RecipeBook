import { IRecipe } from "./recipe.interface";
import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IRegistrationForm } from "./forms/registrationForm.interface";
import { ILoginForm } from "./forms/loginForm.interface";
import { ITokenView } from "./forms/token-view.interface";
import { JwtHelperService } from "@auth0/angular-jwt";
import * as moment from "moment";
import { IUserAccount } from "./user-account.interface";


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

    public getUserById(id:string): Observable<IUserAccount> {
        return this.httpClient.get<IUserAccount>(`${this.apiUrl}/${id}`);
    }

    public updateUser(user:IUserAccount): Observable <string> {
        return this.httpClient.put<string>(`${this.apiUrl}/${user.id}`, user);
    }

    public changePassword(user:IUserAccount, newPassword:string): Observable <string> {
        const formData: FormData = new FormData();
        formData.append("newPassword", newPassword);

        return this.httpClient.put<string>(`${this.apiUrl}/${user.id}/password`, formData);
    }


    public getUserRecipes(id:string): Observable<IRecipe[]> {
        return this.httpClient.get<IRecipe[]>(`${this.apiUrl}/${id}/recipe`)
    }

    public getUserFavoriteRecipes(id:string): Observable<IRecipe[]> {
        return this.httpClient.get<IRecipe[]>(`${this.apiUrl}/${id}/favorite`)
    }

    public getUserFavoriteRecipesCount(id:string): Observable<number> {
        return this.httpClient.get<number>(`${this.apiUrl}/${id}/favorite/count`)
    }

    public GetUserLikesCount(id:string): Observable<number> {
        return this.httpClient.get<number>(`${this.apiUrl}/${id}/like/count`)
    }
    
}