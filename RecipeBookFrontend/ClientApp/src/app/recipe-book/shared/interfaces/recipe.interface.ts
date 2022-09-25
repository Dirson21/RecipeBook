import { ICookingStep } from "./cooking-step.interface"
import { IIngredientHeader } from "./ingredient-header.interface"
import { IIngredient } from "./ingredient.interface"
import { ITag } from "./tag.interface"
import { IUserAccount } from "./user-account.interface"

export interface IRecipe {
    id: number,
    name: string,
    image: string,
    description: string,
    cookingTime: number,
    countPerson: number,

    countLike: number,
    countFavorite: number,
    isLike: boolean,
    isFavorite: boolean

    ingredientHeaders: IIngredientHeader[]
    tags: ITag[],
    cookingSteps: ICookingStep[],
    userAccount: IUserAccount
}

export const emptyRecipe = (): IRecipe => ({
    id: 0,
    name: "",
    description: "",
    tags: [],
    cookingSteps: [],
    countPerson: 0,
    image: "",
    cookingTime: 0,
    ingredientHeaders: [],
    userAccount: {
        id: "",
        login: "",
        description: "",
        name: "",
        newPassword: ""
    },
    countLike: 0,
    countFavorite: 0,
    isLike: false,
    isFavorite: false


});

export const recipeInit = <T extends Partial<IRecipe>>(initialValues: T): IRecipe & T => {
    return Object.assign(emptyRecipe(), initialValues);
};