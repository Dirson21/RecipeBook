import { ICookingStep } from "./cookingStep.interface"
import { IIngridient } from "./ingridient.interface"
import { ITag } from "./tag.interface"

export interface IRecipe {
    id: number,
    name: string,
    image: string,
    description:string,
    cookingTime: number,
    countPerson:number,

    ingridients: IIngridient[]
    tags: ITag[],
    cookingSteps: ICookingStep[] 

}