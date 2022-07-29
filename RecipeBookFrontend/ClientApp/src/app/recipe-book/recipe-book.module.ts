import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainPageComponent } from './main-page/main-page.component';
import { MatCardModule } from "@angular/material/card";
import { HeaderComponent } from './header/header.component';
import {MatListModule} from '@angular/material/list';



@NgModule({
  declarations: [
    MainPageComponent,
    HeaderComponent
  ],
  imports: [
    CommonModule,
    MatCardModule,
    MatListModule
  ]
})
export class RecipeBookModule { }
