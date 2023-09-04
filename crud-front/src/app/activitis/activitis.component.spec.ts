import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ActivitisComponent } from './activitis.component';

describe('ActivitisComponent', () => {
  let component: ActivitisComponent;
  let fixture: ComponentFixture<ActivitisComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ActivitisComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ActivitisComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
