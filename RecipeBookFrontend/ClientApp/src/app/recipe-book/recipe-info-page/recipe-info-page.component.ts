import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { switchMap } from 'rxjs';
import { AuthService } from '../shared/auth.service';
import { IRecipe } from '../shared/recipe.interface';
import { RecipeService } from '../shared/recipe.service';

@Component({
  selector: 'app-recipe-info-page',
  templateUrl: './recipe-info-page.component.html',
  styleUrls: ['./recipe-info-page.component.css']
})
export class RecipeInfoPageComponent implements OnInit {

  recipe!:IRecipe
  constructor(private route:ActivatedRoute, private recipeService: RecipeService, public authService: AuthService, public router: Router) { }

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

  public isLoggedUser(): boolean {
    return this.authService.isLoggedUser(this.recipe.userAccount.id)
  }


  public onDeleteButton () {
      this.recipeService.deleteRecipe(this.recipe.id).subscribe({next : ()=> {
        this.router.navigate(["/recipe"]);
      }});
  }

}
