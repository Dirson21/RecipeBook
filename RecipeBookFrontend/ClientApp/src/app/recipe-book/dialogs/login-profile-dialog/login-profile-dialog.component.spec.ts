import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoginProfileDialogComponent } from './login-profile-dialog.component';

describe('LoginProfileDialogComponent', () => {
  let component: LoginProfileDialogComponent;
  let fixture: ComponentFixture<LoginProfileDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LoginProfileDialogComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LoginProfileDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
