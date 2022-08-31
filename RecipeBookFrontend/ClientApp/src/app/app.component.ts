import { ChangeDetectorRef, Component, ViewChild } from '@angular/core';
import { MatInput } from '@angular/material/input';
import { Observable } from 'rxjs';
import { PreloadService } from './recipe-book/shared/preload.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(private loader: PreloadService, private changeDetectorRef: ChangeDetectorRef) {}

  title = 'ClientApp';

  loading!: Observable<boolean>;

  ngOnInit(): void {
    this.loading = this.loader.loading

  }

}
