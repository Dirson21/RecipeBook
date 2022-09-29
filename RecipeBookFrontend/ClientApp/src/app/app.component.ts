import { ChangeDetectorRef, Component, ViewChild } from '@angular/core';
import { MatInput } from '@angular/material/input';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { NavigationService } from './recipe-book/shared/navigation.service';
import { PreloadService } from './recipe-book/shared/preload.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(private navigationService: NavigationService, private loader: PreloadService, private router: Router, private changeDetectorRef: ChangeDetectorRef) { }

  title = 'ClientApp';

  loading!: Observable<boolean>;

  ngOnInit(): void {
    this.loading = this.loader.loading



  }

}
