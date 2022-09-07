import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../shared/auth.service';
import { RecipeService } from '../shared/recipe.service';
import { IUserAccount } from '../shared/user-account.interface';
import { UserAccountService } from '../shared/user-account.service';
import { switchMap } from 'rxjs';
import { IRecipe } from '../shared/recipe.interface';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile-page.component.html',
  styleUrls: ['./user-profile-page.component.css']
})
export class UserProfilePageComponent implements OnInit {

  userAccount!: IUserAccount
  recipes: IRecipe[] = []
  favoriteCount!: number
  likeCount!: number

  constructor(private route: ActivatedRoute, private recipeService: RecipeService,
    public authService: AuthService, public router: Router, private userAccountService: UserAccountService) {

      this.favoriteCount = 0;
      this.likeCount = 0;
  }

  ngOnInit(): void {

    
  
    this.route.paramMap.pipe(
      switchMap(params => params.getAll('id'))
    ).subscribe(id => {
      this.userAccountService.getUserById(id).subscribe({
        next: (user) => {
          this.userAccount = Object.assign({}, user);
        }
      })
      this.userAccountService.getUserRecipes(id).subscribe({
        next: (recipes)=> {
          this.recipes = Object.assign(this.recipes, recipes)
        }
      })
      this.userAccountService.getUserFavoriteRecipesCount(id).subscribe({
        next: (count)=> {
          this.favoriteCount = count;
        }
      })
      this.userAccountService.GetUserLikesCount(id).subscribe({
        next: (count)=> {
          this.likeCount = count;
        }
      })
    })
  }

}
