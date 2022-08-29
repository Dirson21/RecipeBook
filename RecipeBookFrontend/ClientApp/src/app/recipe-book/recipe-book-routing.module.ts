import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RouterModule, Routes } from '@angular/router';
import { RecipePageComponent } from './recipe-page/recipe-page.component';
import { MainPageComponent } from './main-page/main-page.component';
import { AddRecipePageComponent } from './add-recipe-page/add-recipe-page.component';
import { AuthGuard } from './shared/guards/auth.guard';

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
