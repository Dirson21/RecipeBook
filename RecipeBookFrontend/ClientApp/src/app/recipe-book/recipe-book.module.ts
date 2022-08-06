import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainPageComponent } from './main-page/main-page.component';
import { MatCardModule } from "@angular/material/card";
import { HeaderComponent } from './header/header.component';
import {MatListModule} from '@angular/material/list';
import {MatButtonModule} from '@angular/material/button';
import { AngularSvgIconModule } from 'angular-svg-icon';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { MatIconModule } from '@angular/material/icon'
import {MatInputModule} from '@angular/material/input';
import { FooterComponent } from './footer/footer.component';
import { RecipePageComponent } from './recipe-page/recipe-page.component';
import {  RouterModule } from '@angular/router';
import { RecipeBookRoutingModule } from './recipe-book-routing.module';
import { RecipeItemComponent } from './recipe-item/recipe-item.component';


@NgModule({
  declarations: [
    MainPageComponent,
    HeaderComponent,
    FooterComponent,
    RecipePageComponent,
    RecipeItemComponent
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
    
  
  ]
})
export class RecipeBookModule { }
