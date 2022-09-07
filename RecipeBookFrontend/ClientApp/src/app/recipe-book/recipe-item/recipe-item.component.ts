import { Component, Input, OnInit } from '@angular/core';
import { IRecipe } from '../shared/recipe.interface';
import { RecipeService } from '../shared/recipe.service';

@Component({
  selector: 'app-recipe-item',
  templateUrl: './recipe-item.component.html',
  styleUrls: ['./recipe-item.component.css']
})
export class RecipeItemComponent implements OnInit {

  constructor(private recipeService: RecipeService) { }

  @Input() recipe!: IRecipe
  @Input() isRecipeTitle: boolean = true;

  ngOnInit(): void {
  }


  public favorite () {
    this.recipeService.favoriteRecipe(this.recipe).subscribe({next: ()=> {
    }})
    this.recipe.countFavorite += 1;
    this.recipe.isFavorite = true;
  }

  public removeFavorite() {
    this.recipeService.removeFavoriteRecipe(this.recipe).subscribe({next: ()=> {
    }})
    this.recipe.countFavorite -= 1;
    this.recipe.isFavorite = false;
  }

  public like () {
    this.recipeService.likeRecipe(this.recipe).subscribe({next: () => {
    }});
    this.recipe.countLike += 1;
    this.recipe.isLike = true;
  }

  public removeLike () {
    this.recipeService.removeLikeRecipe(this.recipe).subscribe({next: () => {
    }});
    this.recipe.countLike -= 1;
    this.recipe.isLike = false;
  }


  

}
