import { Component, Input, IterableDiffers, OnInit, ViewEncapsulation } from '@angular/core';
import { AbstractControl, FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatChipEvent } from '@angular/material/chips';
import { filter, Observable, Observer } from 'rxjs';
import { ICookingStep } from '../shared/cooking-step.interface';
import { IIngredientHeader } from '../shared/ingredient-header.interface';
import { IIngredient } from '../shared/ingredient.interface';
import { emptyRecipe, IRecipe } from '../shared/recipe.interface';
import { RecipeService } from '../shared/recipe.service';
import { ITag } from '../shared/tag.interface';
import { MatChipInputEvent } from '@angular/material/chips';
import { COMMA, ENTER } from '@angular/cdk/keycodes';
import { ICON_REGISTRY_PROVIDER } from '@angular/material/icon';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { switchMap } from 'rxjs';

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
  readonly imgUrl = `http://localhost:4200/data/recipe`;

  mySubscription;
  
  constructor(private fb: FormBuilder, private recipeService: RecipeService, private route: ActivatedRoute, private router: Router) {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.mySubscription = this.router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {
         // Trick the Router into believing it's last link wasn't previously loaded
         this.router.navigated = false;
      }
    }); 

  }

  ngOnDestroy(){
    if (this.mySubscription) {
      this.mySubscription.unsubscribe();
    }
  }

  recipe!: IRecipe


  form!: FormGroup

  public update: boolean = false

  ngOnInit(): void {


    if (this.route.snapshot.params["id"]) {
      this.route.paramMap.pipe(
        switchMap(params => params.getAll('id'))
      ).subscribe({
        next: id => {
          this.recipeService.getRecipe(+id).subscribe({
            next: recipe => {
              this.recipe = Object.assign({}, recipe);
              this.initForm(recipe)
              

            },
            complete: () => {
              let recipeImage: HTMLImageElement = document.getElementById("recipeImg") as HTMLImageElement;
              recipeImage.src = `${this.imgUrl}/${this.recipe.image}`;
              recipeImage.classList.add("image-preview");
              this.update = true;
            }
          })
        },
      })
    }

    this.recipe = emptyRecipe();
    this.recipe.cookingSteps.push({ id: 0, stepNumber: 0, description: "", recipeId: 0 })
    this.recipe.ingredientHeaders.push({ id: 0, name: "", ingredients: [] })
   
    this.initForm(this.recipe);
   

  }

  public initForm(recipe: IRecipe) {

    const cookingTime = recipe.cookingTime != 0 ? recipe.cookingTime : '';
    const countPerson = recipe.countPerson != 0 ? recipe.countPerson : '';

    this.form = this.fb.group({
      name: [recipe.name, [Validators.required]],
      description: [recipe.description, [Validators.required]],
      cookingTime: [cookingTime, [Validators.required]],
      countPerson: [countPerson, [Validators.required]],

      tags: this.initTagFormArray(recipe.tags),

      ingredientHeaders: this.initIngredientFormArray(recipe.ingredientHeaders),

      cookingSteps: this.initStepFormArray(recipe.cookingSteps),
    })

  }

  public initTagFormArray(tags: ITag[]) {
    let formArray: FormArray = this.fb.array<any>([], Validators.required)
    console.log(formArray);
    tags.forEach(tag => {
      formArray.push(this.initTagForm(tag.name))
    })
    console.log(formArray);
    return formArray;
  }

  public initIngredientFormArray(ingredientHeaders: IIngredientHeader[]) {
    let formArray: FormArray = this.fb.array([], Validators.required)
    ingredientHeaders.forEach(ingredientheader => {
      let ingredients: string = ingredientheader.ingredients.map(s => s.name).join("\n");
      formArray.push(this.initIngridientForm(ingredientheader.name, ingredients))
    })
    return formArray;
  }

  public initStepFormArray(cookingSteps: ICookingStep[]) {
    let formArray: FormArray = this.fb.array([], Validators.required);
    cookingSteps.forEach(step => {
      formArray.push(this.initStepForm(step.description));
    })
    return formArray
  }

  public initTagForm(name: string): FormGroup {
    return this.fb.group({
      name: [name, [Validators.required]]
    });
  }

  public initIngridientForm(name: string = '', ingredient: string = ''): FormGroup {
    return this.fb.group({
      name: [name, [Validators.required]],
      ingredients: [ingredient, [Validators.required]]
    });
  }

  public initStepForm(description: string = ''): FormGroup {
    return this.fb.group({
      description: [description, [Validators.required]],
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

  public onFileChanged(event: any) {
    console.log(event);

    let files: FileList = event.target.files;
    console.log(files)
    if (files.length == 0){
      let recipeImage: HTMLImageElement = document.getElementById("recipeImg") as HTMLImageElement;

      return;
    }


    let recipeImage: HTMLImageElement = document.getElementById("recipeImg") as HTMLImageElement;
    let reader: FileReader = new FileReader();
    reader.readAsDataURL(files[0]);
    reader.onload = (_event) => {
      recipeImage.src = reader.result as string;
      recipeImage.classList.add("image-preview");
    }
  }

  private getRecipeImage(): File | null {
    const input: HTMLInputElement = document.getElementById("imagePreview") as HTMLInputElement
    const file: FileList = input.files!
    if (file.length == 0) {
      return null;
    }
    return file[0];
  }

  private getIngredientFromRaw(tagsRaw: string): IIngredient[] {
    let ingredients: IIngredient[] = [];

    tagsRaw.trim().split("\n").filter(s => s.length > 0).forEach((value: string) => {
      ingredients.push({ id: 0, name: value, recipeId: 0 })
    });
    return ingredients;
  }

  private getCookingStepsFromControls(): ICookingStep[] {
    let cookingStep: ICookingStep[] = [];
    this.stepForms.controls.forEach((control, index) => {
      cookingStep.push({
        id: 0,
        recipeId: 0,
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
    const image: File | null = this.getRecipeImage();
    if (image == null) return;
    if (this.form.invalid) return;

    let recipe: IRecipe;

    recipe = Object.assign({}, this.form.value)
    recipe.ingredientHeaders = this.getIngredientHeaderFromControls();
    recipe.image = "";
    recipe.cookingSteps = this.getCookingStepsFromControls()

    console.log(recipe);

    this.recipeService.addRecipe(recipe).subscribe((id) => {

      this.recipeService.addRecipeImage(id, image).subscribe(() => {
        console.log(id);
        this.router.navigate([this.router.url])
    
       
      });

    })
  }

  public updateRecipe() {
    const image: File | null = this.getRecipeImage();
    console.log(this.form);

    if (this.form.invalid) return;
    let recipe: IRecipe;

    recipe = Object.assign(this.recipe, this.form.value);
    console.log(recipe);

    recipe.ingredientHeaders = this.getIngredientHeaderFromControls();

    recipe.cookingSteps = this.getCookingStepsFromControls()



    this.recipeService.updateRecipe(recipe).subscribe({
      next: () => {
        if (image) {
          this.recipeService.addRecipeImage(recipe.id, image).subscribe(() => {
            this.recipe = recipe;
            this.initForm(this.recipe);
          });
        }
        else {
          this.recipe = recipe;
          this.initForm(this.recipe);
        }
      }
    })


  }

}
