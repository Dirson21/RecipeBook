import { Component, Input, IterableDiffers, OnInit, ViewEncapsulation } from '@angular/core';
import { AbstractControl, FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatChipEvent } from '@angular/material/chips';
import { Observer } from 'rxjs';
import { ICookingStep } from '../shared/cooking-step.interface';
import { IIngredientHeader } from '../shared/ingredient-header.interface';
import { IIngredient } from '../shared/ingredient.interface';
import { IRecipe } from '../shared/recipe.interface';
import { RecipeService } from '../shared/recipe.service';
import { ITag } from '../shared/tag.interface';
import { MatChipInputEvent } from '@angular/material/chips';
import {COMMA, ENTER} from '@angular/cdk/keycodes';

@Component({
  selector: 'app-add-recipe-page',
  templateUrl: './add-recipe-page.component.html',
  styleUrls: ['./add-recipe-page.component.css'],

})
export class AddRecipePageComponent implements OnInit {

  minutesSelect: number[] = [
   10, 20, 30, 40, 50, 60, 70
  ];

  countPersonSelect: number[] = [
    1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 15, 20
  ];

  readonly separatorKeysCodes = [ENTER] as const;

  constructor(private fb: FormBuilder, private recipeService:RecipeService) {

  }

  form!: FormGroup

  ngOnInit(): void {
    this.form = this.fb.group({
      name: ['', [Validators.required]],
      description: ['', [Validators.required]],
      tags: this.fb.array([], Validators.required),
      cookingTime: ['', [Validators.required]],
      countPerson: ['', [Validators.required]],
      ingredientHeaders: this.fb.array([
        this.initIngridientForm()
      ]),
      cookingSteps: this.fb.array([
        this.initStepForm()
      ]),
    })
  }

  public initTagForm(name: string): FormGroup {
    return this.fb.group({
      name: [name, [Validators.required]]
    });
  }

  public initIngridientForm():FormGroup {
    return this.fb.group({
      name: ['', [Validators.required]],
      ingredients: ['', [Validators.required]]
    });
  }

  public initStepForm():FormGroup {
    return this.fb.group({
      description: ['', [Validators.required]],
    });
  }

  public addStep() {
    this.stepForms.push(this.initStepForm())
  }

  public removeStep(i: number) {
    this.stepForms.removeAt(i)
  }

  public addTag(event: MatChipInputEvent): void {
    const value = (event.value || '').trim().toLowerCase();
    console.log(value);
    if (value) {
      this.tagForms.push(this.initTagForm(value));
    }

    event.chipInput.clear();
  }

  public removeTag(i: number): void {
      this.tagForms.removeAt(i);
  }

  get ingredientForms() {
    return this.form.controls["ingredientHeaders"] as FormArray;
  }

  get stepForms() {
    return this.form.controls["cookingSteps"] as FormArray
  }

  get tagForms() {
    return this.form.controls["tags"] as FormArray;
  }

  public getStepForm(i: number) {
    return this.stepForms.at(i) as FormGroup;
  }

  public getIngredientForm(i: number) {
    return this.ingredientForms.at(i) as FormGroup
  }

  public getTagForm(i: number) {
    return this.tagForms.at(i) as FormGroup
  }

  public addIngredientHeader() {
    this.ingredientForms.push(this.initIngridientForm())
  }

  public removeIngridientHeader(i: number) {
    this.ingredientForms.removeAt(i)
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

  private getRecipeImage() : File | null { 
    const input: HTMLInputElement = document.getElementById("imagePreview") as HTMLInputElement
    const file: FileList = input.files!
    if (file.length == 0) {
      return null;
    }
    return file[0];
  }

  private getIngredientFromRaw(tagsRaw: string): IIngredient[] {
    let ingredients: IIngredient[] = [];

    tagsRaw.split("\n").forEach((value:string) => {
        ingredients.push({id:0, name:value, recipeId: 0})
    });
    return ingredients;
  }

  private getCookingStepsFromControls():ICookingStep[] {
    let cookingStep: ICookingStep[] = [];
    this.stepForms.controls.forEach((control, index) => {
      cookingStep.push({
          id: 0,
          recipeId:0,
          stepNumber: index + 1,
          description: control.get("description")?.value
      })
    })
    return cookingStep;
  }

  private getIngredientHeaderFromControls(): IIngredientHeader[] {
    let ingredientHeaders: IIngredientHeader[] = []
    this.ingredientForms.controls.forEach((control, index) => {
      ingredientHeaders.push({
        id: 0,
        name: control.get("name")?.value,
        ingredients: this.getIngredientFromRaw(control.get("ingredients")?.value)
      })
    })
    return ingredientHeaders;
  }

  public addRecipe() {
    const image: File|null = this.getRecipeImage();
    if (image == null) return;
    if (this.form.invalid) return;

    let recipe: IRecipe;

    recipe = Object.assign({}, this.form.value)
    recipe.ingredientHeaders = this.getIngredientHeaderFromControls();
    recipe.image = "";
    recipe.cookingSteps = this.getCookingStepsFromControls()

    console.log(recipe);
    
    this.recipeService.addRecipe(recipe).subscribe((id) => {

        this.recipeService.addRecipeImage(id, image).subscribe();
        console.log(id);
        location.href = location.href;
    })
  }
}
