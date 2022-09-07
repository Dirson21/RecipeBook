import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { switchMap } from 'rxjs';
import { IRecipe } from '../shared/recipe.interface';
import { RecipeService } from '../shared/recipe.service';
import { UserAccountService } from '../shared/user-account.service';

@Component({
  selector: 'app-favorite-page',
  templateUrl: './favorite-page.component.html',
  styleUrls: ['./favorite-page.component.css']
})
export class FavoritePageComponent implements OnInit {

  constructor(private userAccountService: UserAccountService, private route:ActivatedRoute) { }

  recipes:IRecipe[] = []

  ngOnInit(): void {
    this.route.paramMap.pipe(
      switchMap(params => params.getAll('id'))
    ).subscribe(id => {
      this.userAccountService.getUserFavoriteRecipes(id).subscribe({
        next: (recipes)=> {
          this.recipes = Object.assign([], recipes);
        }
      })
    })
  }
  

}
