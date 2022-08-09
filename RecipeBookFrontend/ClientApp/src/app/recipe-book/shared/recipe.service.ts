import { IRecipe } from "./recipe.interface";
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable()
export class RecipeService {
    private readonly apiUrl:string = "http://localhost:4200/api/recipe"

    constructor (private readonly httpClient: HttpClient) {

    }

    public getRecipes (): Observable<IRecipe[]> {
        return this.httpClient.get<IRecipe[]>(this.apiUrl);
    }
    
}