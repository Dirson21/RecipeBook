import { Component, IterableDiffers, OnInit } from '@angular/core';
import { AbstractControl, FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Observer } from 'rxjs';
import { ICookingStep } from '../shared/cookingStep.interface';
import { IIngridient } from '../shared/ingridient.interface';
import { IRecipe } from '../shared/recipe.interface';
import { RecipeService } from '../shared/recipe.service';
import { ITag } from '../shared/tag.interface';


@Component({
  selector: 'app-add-recipe-page',
  templateUrl: './add-recipe-page.component.html',
  styleUrls: ['./add-recipe-page.component.css']
})
export class AddRecipePageComponent implements OnInit {

  minutesSelect: number[] = [
   10, 20, 30, 40, 50, 60, 70
  ];

  countPersonSelect: number[] = [
    1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 15, 20
   ];

  
  constructor(private fb: FormBuilder, private recipeService:RecipeService) { }

  form!: FormGroup


  ngOnInit(): void {
    this.form = this.fb.group({
      recipeName: ['', [Validators.required]],
      recipeDescription: ['', [Validators.required, Validators.maxLength(150)]],
      recipeTags: ['', [Validators.required]],
      recipeCookingTime: ['', [Validators.required]],
      recipeCountPerson: ['', [Validators.required]],
      ingridients: this.fb.array([
        this.initIngridientForm()
      ]),
      steps: this.fb.array([
        this.initStepForm()
      ])
    })
   
  }


  public initIngridientForm():FormGroup {
    return this.fb.group({
      ingridientHeader: ['', [Validators.required]],
      ingridientProduct: ['', [Validators.required]]
    });
  }

  public initStepForm():FormGroup {
    return this.fb.group({
      stepDescription: ['', [Validators.required]],
    });
  }

  public addStep() {
    this.steps.push(this.initStepForm())
  }
  public removeStep(i: number) {
    this.steps.removeAt(i)
  }


  get recipeNameControl (): AbstractControl {
    return this.form.get("recipeName")!
  }
  get recipeDescriptionControl (): AbstractControl {
    return this.form.get("recipeDescription")!
  }
  get recipeTagsControl (): AbstractControl {
    return this.form.get("recipeTags")!
  }
  get recipeCookingTimeControl (): AbstractControl {
    return this.form.get("recipeCookingTime")!
  }
  get recipeCountPersonControl (): AbstractControl {
    return this.form.get("recipeCountPerson")!
  }

  get ingridients() {
    return this.form.controls["ingridients"] as FormArray;
  }

  get steps() {
    return this.form.controls["steps"] as FormArray
  }


  public getStepForm(i: number) {
    return this.steps.at(i) as FormGroup;
  }

  public getIngridientForm(i: number) {
    return this.ingridients.at(i) as FormGroup
  }

  public addIngridientHeader() {
    this.ingridients.push(this.initIngridientForm())
  }

  public removeIngridientHeader(i: number) {
    this.ingridients.removeAt(i)
  }



  public onFileChanged(event:any ) {
      console.log(event);

      let files: FileList = event.target.files; 
      console.log(files)
      if (files.length == 0) return;

      let recipeImage: HTMLImageElement  = document.getElementById("recipeImg") as  HTMLImageElement;
      let reader: FileReader = new FileReader();
      reader.readAsDataURL(files[0]);
      reader.onload = (_event) => {
        recipeImage.src = reader.result as string;
        recipeImage.classList.add("image-preview");
      
      } 
    }

 


  private getTagFromRaw(tagsRaw: string): ITag[] {
    let tags: ITag[] = [];

    tagsRaw.split(" ").forEach((value:string) => {
        tags.push({id:0, name:value})
    });
    return tags;
  }

  private getIngridientFromRaw(tagsRaw: string): IIngridient[] {
    let ingridients: IIngridient[] = [];

    tagsRaw.split("\n").forEach((value:string) => {
        ingridients.push({id:0, name:value, recipeId: 0})
    });
    return ingridients;
  }

  private getCookingStepsFromControls():ICookingStep[] {
    let cookingStep: ICookingStep[] = [];
    this.steps.controls.forEach((control, index) => {
      cookingStep.push({
          id: 0,
          recipeId:0,
          stepNumber: index + 1,
          description: control.value
      })
    })
    return cookingStep;
  }

  public addRecipe() {
    if (this.form.invalid) return;

    let recipe: IRecipe = {
      id: 0,
      name: this.recipeNameControl.value,
      description: this.recipeDescriptionControl.value,
      image: "",
      cookingTime: this.recipeCookingTimeControl.value,
      countPerson: this.recipeCountPersonControl.value,
      tags: this.getTagFromRaw(this.recipeTagsControl.value),
      cookingSteps: this.getCookingStepsFromControls(),
      ingridients: []
    };

    console.log(recipe);

    this.recipeService.addRecipe(recipe).subscribe((id: number) => {
        console.log(id);

    })


  }



}
