import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { switchMap } from 'rxjs';
import { IRecipe } from '../shared/recipe.interface';
import { RecipeService } from '../shared/recipe.service';

@Component({
  selector: 'app-recipe-info-page',
  templateUrl: './recipe-info-page.component.html',
  styleUrls: ['./recipe-info-page.component.css']
})
export class RecipeInfoPageComponent implements OnInit {

  recipe!:IRecipe
  constructor(private route:ActivatedRoute, private recipeService: RecipeService) { }

  ngOnInit(): void {

    this.route.paramMap.pipe(
      switchMap(params=> params.getAll('id'))
    ).subscribe(id => {
      this.recipeService.getRecipe(+id).subscribe(recipe => {
          this.recipe = Object.assign({}, recipe);
          console.log(recipe)
      } )
    })
  }

}
