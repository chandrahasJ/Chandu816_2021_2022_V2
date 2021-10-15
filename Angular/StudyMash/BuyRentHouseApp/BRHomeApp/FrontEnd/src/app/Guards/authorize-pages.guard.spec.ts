import { TestBed } from '@angular/core/testing';

import { AuthorizePagesGuard } from './authorize-pages.guard';

describe('AuthorizePagesGuard', () => {
  let guard: AuthorizePagesGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(AuthorizePagesGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
