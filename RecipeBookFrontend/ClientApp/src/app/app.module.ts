import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MainPageComponent } from './recipe-book/main-page/main-page.component';

import { RecipeBookModule } from './recipe-book/recipe-book.module';





@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RecipeBookModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
