import { ICookingStep } from "./cooking-step.interface"
import { IIngredientHeader } from "./ingredient-header.interface"
import { IIngredient } from "./ingredient.interface"
import { ITag } from "./tag.interface"
import { IUserAccount } from "./user-account.interface"

export interface IRecipe {
    id: number,
    name: string,
    image: string,
    description:string,
    cookingTime: number,
    countPerson:number,

    ingredientHeaders: IIngredientHeader[]
    tags: ITag[],
    cookingSteps: ICookingStep[],
    userAccount: IUserAccount
}