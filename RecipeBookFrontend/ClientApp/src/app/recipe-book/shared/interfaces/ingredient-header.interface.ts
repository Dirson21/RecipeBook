import { IIngredient } from "./ingredient.interface";

export interface IIngredientHeader {
    id: number,
    name: string,
    ingredients: IIngredient[]
}