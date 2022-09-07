import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BackItemComponent } from './back-item.component';

describe('BackItemComponent', () => {
  let component: BackItemComponent;
  let fixture: ComponentFixture<BackItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BackItemComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BackItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
