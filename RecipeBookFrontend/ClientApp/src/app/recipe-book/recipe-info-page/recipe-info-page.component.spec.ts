import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RecipeInfoPageComponent } from './recipe-info-page.component';

describe('RecipeInfoPageComponent', () => {
  let component: RecipeInfoPageComponent;
  let fixture: ComponentFixture<RecipeInfoPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RecipeInfoPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RecipeInfoPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
