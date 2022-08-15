import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';


@Component({
  selector: 'app-add-recipe-page',
  templateUrl: './add-recipe-page.component.html',
  styleUrls: ['./add-recipe-page.component.css']
})
export class AddRecipePageComponent implements OnInit {

  minutes: number[] = [
   10, 20, 30, 40, 50, 60, 70
  ];

  constructor() { }

  formGroup!: FormGroup
  imageSrc!: string;

  ngOnInit(): void {
  }

 
}
