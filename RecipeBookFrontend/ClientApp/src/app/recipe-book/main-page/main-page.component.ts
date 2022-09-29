import { Component, OnInit } from '@angular/core';
import { Dialog } from '@angular/cdk/dialog';
import { RegistrationDialogComponent, RegistrationDialogExitStatus } from '../dialogs/registration-dialog/registration-dialog.component';
import { MatDialog, MatDialogConfig, MatDialogRef } from '@angular/material/dialog';
import { LoginProfileDialogComponent, LoginProfileDialogExitStatus } from '../dialogs/login-profile-dialog/login-profile-dialog.component';
import { LoginDialogComponent, LoginDialogExitState } from '../dialogs/login-dialog/login-dialog.component';
import { DialogHelper } from '../shared/dialog-helper';
import { AuthService } from '../shared/auth.service';
import { NavigationEnd, Router } from '@angular/router';
import { AbstractControl, FormBuilder, FormGroup } from '@angular/forms';
import { RecipeService } from '../shared/recipe.service';
import { IRecipe } from '../shared/interfaces/recipe.interface';


@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.css']
})
export class MainPageComponent implements OnInit {


  constructor(public dialogHelper: DialogHelper, public authService: AuthService, private router: Router, private fb: FormBuilder,
    private recipeService: RecipeService) {

  }

  form!: FormGroup;

  recipe!: IRecipe

  ngOnInit(): void {
    this.form = this.fb.group({
      search: ['']
    })

    this.recipeService.getRecipeDay().subscribe({
      next: (value) => {
        if (value.id != 0) {
          this.recipe = Object.assign({}, value);
        }
      }
    })


  }

  get searchControl(): AbstractControl {
    return this.form.get("search")!
  }

  public onLoginButton() {
    this.dialogHelper.showLoginDialog();
  }

  public inputTag(name: string) {
    this.router.navigate(["/recipe"], { queryParams: { search: name } })
  }

  public searchRecipe() {
    if (this.form.invalid) return;

    let name: string = this.searchControl.value;

    if (name != '') {
      this.router.navigate(["/recipe"], { queryParams: { search: name } });
      return;
    }

    this.router.navigate(["/recipe"]);

  }

  public like() {
    if (!this.authService.isLoggedIn()) {
      this.dialogHelper.showLoginDialog()
      return
    }

    this.recipeService.likeRecipe(this.recipe).subscribe({
      next: () => {
        this.recipe.countLike += 1;
        this.recipe.isLike = true;
      }
    });
  }

  public removeLike() {
    if (!this.authService.isLoggedIn()) {
      this.dialogHelper.showLoginDialog()
      return
    }

    this.recipeService.removeLikeRecipe(this.recipe).subscribe({
      next: () => {
        this.recipe.countLike -= 1;
        this.recipe.isLike = false;
      }
    });
  }

}
