import { Component, OnInit } from '@angular/core';
import { NavigationService } from '../shared/navigation.service';

@Component({
  selector: 'app-back-item',
  templateUrl: './back-item.component.html',
  styleUrls: ['./back-item.component.css']
})
export class BackItemComponent implements OnInit {

  constructor(private navigationService: NavigationService) { }

  ngOnInit(): void {
  }

  back() {
    this.navigationService.back();
  }

}
