import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { PreloadService } from '../shared/preload.service';
import { IRecipe } from '../shared/recipe.interface';
import { RecipeService } from '../shared/recipe.service';

@Component({
  selector: 'app-recipe-page',
  templateUrl: './recipe-page.component.html',
  styleUrls: ['./recipe-page.component.css']
})
export class RecipePageComponent implements OnInit {

  public recipes: IRecipe[] = []

  form!: FormGroup

  private start: number = 0;

  constructor(private recipeService: RecipeService,
    public loader: PreloadService,
    private fb: FormBuilder, private route: ActivatedRoute, private router: Router) {

  }

  ngOnInit(): void {
    this.form = this.fb.group({
      search: ['']
    })

    this.route.queryParams.subscribe(
      (queryParam: any) => {
        let param: string | undefined = queryParam['search'];
        console.log(param);
        if (param) {
          this.inputTag(param);
        }
        else {
          this.getNextRecipes(4, true);
        }
      });


  }

  public getRecipes() {
    this.recipeService.getRecipes().subscribe(s => {
      this.recipes = Object.assign(s)
    });
  }

  private getRecipesRange(count: number) {

    this.recipeService.getRecipesRange(this.start, count).subscribe(s => {

      this.recipes = this.recipes.concat(s);
      this.start = this.recipes.length;
    })

  }

  private searchRecipe(count: number) {

    if (this.form.invalid) return;

    let search: string = this.searchControl.value;

    if (search == '') {
      this.getRecipesRange(count);
      return;
    }

    this.recipeService.searchRecipe(search.trim(), this.start, count).subscribe({
      next: (recipes) => {
        this.recipes = this.recipes.concat(recipes);
        this.start = this.recipes.length;
      }
    })
  }

  public getNextRecipes(count: number, isStart: boolean = false) {
    if (isStart) {
      window.scrollTo(0, 0);
      this.start = 0;
      this.recipes = [];
    }
    this.searchRecipe(count);

  }

  private inputTag(tag: string) {

    this.searchControl.setValue(tag);
    this.getNextRecipes(4, true);
  }

  get searchControl(): AbstractControl {
    return this.form.get("search")!
  }

  public searchRecipeClick(search: string = '') {

    if (search == '') {

      let name: string = this.searchControl.value;
      if (name != '') {
        this.router.navigate(["/recipe"], {
          queryParams: {
            search: name
          }
        })
      }
      else {
        this.router.navigate(["/recipe"]);
      }

      return;
    }

    this.router.navigate(["/recipe"], {
      queryParams: {
        search: search
      }
    })


  }





}
