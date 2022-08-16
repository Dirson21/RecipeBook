import { Component, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';


@Component({
  selector: 'app-add-recipe-page',
  templateUrl: './add-recipe-page.component.html',
  styleUrls: ['./add-recipe-page.component.css']
})
export class AddRecipePageComponent implements OnInit {

  minutes: number[] = [
   10, 20, 30, 40, 50, 60, 70
  ];

  public imgUrl!: string;
  constructor() { }

  formGroup!: FormGroup
  imageSrc!: string;

  ngOnInit(): void {
 
   
  }





  onFileChanged(event:any ) {
    console.log(event);

    let files: FileList = event.target.files; 
    console.log(files)
    if (files.length == 0) return;

    let recipeImage: HTMLImageElement  = document.getElementById("recipeImg") as  HTMLImageElement;
    let reader: FileReader = new FileReader();
    reader.readAsDataURL(files[0]);
    reader.onload = (_event) => {
      recipeImage.src = reader.result as string;
      recipeImage.classList.add("image-preview");
    
    }

     
    
  }

 
}
