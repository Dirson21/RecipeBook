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

  constructor(private recipeService:RecipeService) { 
    this.getRecipes();
  
  }

  ngOnInit(): void {
  }

  public getRecipes()
  {
    this.recipeService.getRecipes().subscribe(s => {
      this.recipes = Object.assign(s)
    });
  }

}
