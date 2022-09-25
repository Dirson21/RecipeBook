import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../shared/auth.service';
import { RecipeService } from '../shared/recipe.service';
import { IUserAccount } from '../shared/user-account.interface';
import { UserAccountService } from '../shared/user-account.service';
import { switchMap } from 'rxjs';
import { IRecipe } from '../shared/recipe.interface';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ErrorResponse } from '../shared/error-response.intefrace';

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

  isShowPassword:boolean = false;
  isReadOnly:boolean = true;

  form!: FormGroup

  constructor(private route: ActivatedRoute, private recipeService: RecipeService,
    public authService: AuthService, public router: Router, private userAccountService: UserAccountService,
    private fb: FormBuilder) {

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
          this.initForm(user)
        }
      })
      this.userAccountService.getUserRecipes(id).subscribe({
        next: (recipes) => {
          this.recipes = Object.assign(this.recipes, recipes)
        }
      })
      this.userAccountService.getUserFavoriteRecipesCount(id).subscribe({
        next: (count) => {
          this.favoriteCount = count;
        }
      })
      this.userAccountService.GetUserLikesCount(id).subscribe({
        next: (count) => {
          this.likeCount = count;
        }
      })
    })
  }

  initForm(user: IUserAccount) {
    console.log(user);
    this.form = this.fb.group({
      login: [user.login, [Validators.required]],
      name: [user.name, [Validators.required]],
      newPassword: ['', [Validators.minLength(8)]],
      description: [user.description]

    })

  }

  likeAction(isLike: boolean) {
    this.likeCount = isLike ? this.likeCount + 1 : this.likeCount - 1
  }

  favoriteAction(isFavorite: boolean) {
    this.favoriteCount = isFavorite ? this.favoriteCount + 1 : this.favoriteCount - 1
  }

  updateUser() {

    if (this.form.invalid) {
      return;
    }

    let user: IUserAccount = Object.assign(this.userAccount, this.form.value);

    let newPassword: string|undefined = this.passwordControl.value

   

    console.log(user);

    this.userAccountService.updateUser(user).subscribe({
      next: (id) => {
        console.log(id);
        this.userAccount = user;
        this.authService.updateName(user.name);

        this.passwordControl.setValue("");
        this.changeFormState();

      },
      error: (err) => {
        const errorResponse: ErrorResponse = err.error;

        if (errorResponse.type == "InvalidLoginException") {
          this.loginControl.setErrors({
            duplicateLogin: true
          }) }

        else if (errorResponse.type == "InvalidPasswordException") {
          this.passwordControl.setErrors({invalidPassword: true});
        }
      }})
    

  }

  changePasswordType()
  {
    this.isShowPassword = !this.isShowPassword;
  }

  get passwordControl(): AbstractControl {
    return this.form.get("newPassword")!
  }

  get loginControl(): AbstractControl {
    return this.form.get("login")!
  }

  changeFormState() {
    this.isReadOnly = !this.isReadOnly;

  }

}
