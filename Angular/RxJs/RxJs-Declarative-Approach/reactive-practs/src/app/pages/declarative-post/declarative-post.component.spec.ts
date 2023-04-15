import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeclarativePostComponent } from './declarative-post.component';

describe('DeclarativePostComponent', () => {
  let component: DeclarativePostComponent;
  let fixture: ComponentFixture<DeclarativePostComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeclarativePostComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DeclarativePostComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
