import { IRecipe } from "./recipe.interface"

export interface ITag {
    id:number,
    name:string,
    image:string,
    description: string
    recipes: IRecipe[]
}