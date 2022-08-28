import { Component, OnInit } from '@angular/core';
import { IRecipe } from '../shared/recipe.interface';
import { RecipeService } from '../shared/recipe.service';

@Component({
  selector: 'app-recipe-page',
  templateUrl: './recipe-page.component.html',
  styleUrls: ['./recipe-page.component.css']
})
export class RecipePageComponent implements OnInit {

  public recipes: IRecipe[] = []

  private start: number = 0;

  constructor(private recipeService: RecipeService) {
    this.getRecipesRange(4);

  }

  ngOnInit(): void {
  }

  public getRecipes() {
    this.recipeService.getRecipes().subscribe(s => {
      this.recipes = Object.assign(s)
    });
  }

  public getRecipesRange(count: number) {

    this.recipeService.getRecipesRange(this.start, count).subscribe(s => {

      this.start += s.length;
      this.recipes = this.recipes.concat(s);
    })

  }

}
