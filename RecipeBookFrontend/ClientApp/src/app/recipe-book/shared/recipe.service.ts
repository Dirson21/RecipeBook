import { IRecipe } from "./recipe.interface";
import { HttpClient, HttpParams } from "@angular/common/http";
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
    public getRecipesRange (start:number, count:number): Observable<IRecipe[]> {
        return this.httpClient.get<IRecipe[]>(`${this.apiUrl}/range`, {
            params: new HttpParams().set("start", start).set("count", count)
        });
    }
    
}