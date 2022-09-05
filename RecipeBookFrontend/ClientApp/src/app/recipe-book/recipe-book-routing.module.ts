import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RouterModule, Routes } from '@angular/router';
import { RecipePageComponent } from './recipe-page/recipe-page.component';
import { MainPageComponent } from './main-page/main-page.component';
import { AddRecipePageComponent } from './add-recipe-page/add-recipe-page.component';
import { AuthGuard } from './shared/guards/auth.guard';
import { RecipeInfoPageComponent } from './recipe-info-page/recipe-info-page.component';
import { UserProfilePageComponent } from './user-profile-page/user-profile-page.component';
import { UserOwnerGuard } from './shared/guards/user-owner-guard';

const routes: Routes = [
  {
    path: "recipe-book",
    component: MainPageComponent
  },

  {
    path: "recipe",
    component: RecipePageComponent,
  },

  {
    path: "recipe/add-recipe",
    component: AddRecipePageComponent,
    canActivate: [AuthGuard],
    canActivateChild: [AuthGuard]
  },
  
  {
    path: "recipe/:id",
    component: RecipeInfoPageComponent
  },

  {
    path: "recipe/:id/update",
    component: AddRecipePageComponent
  },

  {
    path: "user/:id",
    component: UserProfilePageComponent,
    canActivate: [AuthGuard, UserOwnerGuard],
    canActivateChild: [AuthGuard, UserOwnerGuard]
  },

  {
    path: "**",
    component: MainPageComponent
  }

]


@NgModule({
  declarations: [

  ],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class RecipeBookRoutingModule { }
