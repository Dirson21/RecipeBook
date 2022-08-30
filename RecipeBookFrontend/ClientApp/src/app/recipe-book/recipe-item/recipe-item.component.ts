import { Component, Input, OnInit } from '@angular/core';
import { IRecipe } from '../shared/recipe.interface';

@Component({
  selector: 'app-recipe-item',
  templateUrl: './recipe-item.component.html',
  styleUrls: ['./recipe-item.component.css']
})
export class RecipeItemComponent implements OnInit {

  constructor() { }

  @Input() recipe!: IRecipe
  @Input() isRecipeTitle: boolean = true;

  ngOnInit(): void {
  }

}
