import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AuthService } from '../shared/auth.service';
import { DialogHelper } from '../shared/dialog-helper';
import { IRecipe } from '../shared/recipe.interface';
import { RecipeService } from '../shared/recipe.service';

@Component({
  selector: 'app-recipe-item',
  templateUrl: './recipe-item.component.html',
  styleUrls: ['./recipe-item.component.css']
})
export class RecipeItemComponent implements OnInit {

  constructor(private recipeService: RecipeService, private authService: AuthService, private dialogHelper: DialogHelper) { }

  @Input() recipe!: IRecipe
  @Input() isRecipeTitle: boolean = true;
  @Output() likeEvent: EventEmitter<boolean> = new EventEmitter<boolean>();
  @Output() favoriteEvent: EventEmitter<boolean> = new EventEmitter<boolean>();
  @Output() clickTagEvent: EventEmitter<string> = new EventEmitter<string>();

  ngOnInit(): void {
  }


  public favorite() {
    if (!this.authService.isLoggedIn()) {
      this.dialogHelper.showLoginDialog()
      return
    }

    this.recipeService.favoriteRecipe(this.recipe).subscribe({
      next: () => {
        this.recipe.countFavorite += 1;
        this.recipe.isFavorite = true;
        this.favoriteEvent.emit(this.recipe.isFavorite);
      }
    })

  }

  public removeFavorite() {
    if (!this.authService.isLoggedIn()) {
      this.dialogHelper.showLoginDialog()
      return
    }

    this.recipeService.removeFavoriteRecipe(this.recipe).subscribe({
      next: () => {
        this.recipe.countFavorite -= 1;
        this.recipe.isFavorite = false;
        this.favoriteEvent.emit(this.recipe.isFavorite);
      }
    })

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
        this.likeEvent.emit(this.recipe.isLike);
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
        this.likeEvent.emit(this.recipe.isLike);
      }
    });
  }

  public clickTag(tag: string) {
    this.clickTagEvent.emit(tag);
  }




}
