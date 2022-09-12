import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainPageComponent } from './main-page/main-page.component';
import { MatCardModule } from "@angular/material/card";
import { HeaderComponent } from './header/header.component';
import { MatListModule } from '@angular/material/list';
import { MatButtonModule } from '@angular/material/button';
import { AngularSvgIconModule } from 'angular-svg-icon';
import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { MatIconModule } from '@angular/material/icon'
import { MatInputModule } from '@angular/material/input';

import { RecipePageComponent } from './recipe-page/recipe-page.component';
import { RouterModule } from '@angular/router';
import { RecipeBookRoutingModule } from './recipe-book-routing.module';
import { RecipeItemComponent } from './recipe-item/recipe-item.component';
import { RecipeService } from './shared/recipe.service';
import { BrowserModule } from '@angular/platform-browser';
import { AddRecipePageComponent } from './add-recipe-page/add-recipe-page.component';
import { ReactiveFormsModule } from '@angular/forms';
import { MatSelectModule } from '@angular/material/select';
import { MatChipsModule } from '@angular/material/chips';
import { RegistrationDialogComponent } from './dialogs/registration-dialog/registration-dialog.component'
import { MatDialogModule } from '@angular/material/dialog'
import { UserAccountService } from './shared/user-account.service';
import { LoginProfileDialogComponent } from './dialogs/login-profile-dialog/login-profile-dialog.component';
import { LoginDialogComponent } from './dialogs/login-dialog/login-dialog.component';
import { AuthService } from './shared/auth.service';
import { DialogHelper } from './shared/dialog-helper';
import { AuthGuard } from './shared/guards/auth.guard';
import { RecipeInfoPageComponent } from './recipe-info-page/recipe-info-page.component';
import { PreloadService } from './shared/preload.service';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import { UserProfilePageComponent } from './user-profile-page/user-profile-page.component';
import { UserOwnerGuard } from './shared/guards/user-owner-guard';
import { FavoritePageComponent } from './favorite-page/favorite-page.component';
import { NavigationService } from './shared/navigation.service';
import { BackItemComponent } from './back-item/back-item.component';


@NgModule({
  declarations: [
    MainPageComponent,
    RecipePageComponent,
    RecipeItemComponent,
    AddRecipePageComponent,
    RegistrationDialogComponent,
    LoginProfileDialogComponent,
    LoginDialogComponent,
    RecipeInfoPageComponent,
    UserProfilePageComponent,
    FavoritePageComponent,
    BackItemComponent
  ],
  imports: [
    CommonModule,
    MatCardModule,
    MatListModule,
    MatButtonModule,
    MatIconModule,
    HttpClientModule,
    AngularSvgIconModule.forRoot(),
    MatInputModule,
    RouterModule,
    RecipeBookRoutingModule,
    BrowserModule,
    ReactiveFormsModule,
    MatSelectModule,
    MatChipsModule,
    MatDialogModule,
    MatToolbarModule,
    MatProgressSpinnerModule
  ],
  providers: [
    RecipeService,
    UserAccountService,
    AuthService,
    DialogHelper,
    AuthGuard,
    PreloadService,
    UserOwnerGuard,
    
  ]
})
export class RecipeBookModule { }
