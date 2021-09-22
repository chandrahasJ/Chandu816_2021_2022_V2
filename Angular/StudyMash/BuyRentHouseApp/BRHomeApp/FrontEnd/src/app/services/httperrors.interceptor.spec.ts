import { TestBed } from '@angular/core/testing';

import { HttperrorsInterceptor } from './httperrors.interceptor';

describe('HttperrorsInterceptor', () => {
  beforeEach(() => TestBed.configureTestingModule({
    providers: [
      HttperrorsInterceptor
      ]
  }));

  it('should be created', () => {
    const interceptor: HttperrorsInterceptor = TestBed.inject(HttperrorsInterceptor);
    expect(interceptor).toBeTruthy();
  });
});
