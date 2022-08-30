import { Component, ViewChild } from '@angular/core';
import { MatInput } from '@angular/material/input';
import { PreloadService } from './recipe-book/shared/preload.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(private loader: PreloadService) {}

  title = 'ClientApp';

  loading = this.loader.loading;


}
