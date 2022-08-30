import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AngularSvgIconModule, SvgIconComponent } from 'angular-svg-icon';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './recipe-book/header/header.component';
import { MainPageComponent } from './recipe-book/main-page/main-page.component';
import { RecipeBookModule } from './recipe-book/recipe-book.module';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FooterComponent } from './recipe-book/footer/footer.component';
import { MatButton, MatButtonModule } from '@angular/material/button';
import { AuthInterceptor } from './recipe-book/shared/auth-interceptor';


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent
  ],
  imports: [
    MatCardModule,
    MatListModule,
    BrowserModule,
    AppRoutingModule,
    RecipeBookModule,
    BrowserAnimationsModule,
    CommonModule,
    MatIconModule,
    HttpClientModule,
    AngularSvgIconModule.forRoot(),
    MatButtonModule

  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true,
    },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
