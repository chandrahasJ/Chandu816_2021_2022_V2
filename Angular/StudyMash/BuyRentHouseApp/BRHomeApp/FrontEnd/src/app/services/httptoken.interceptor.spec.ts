import { TestBed } from '@angular/core/testing';

import { HttptokenInterceptor } from './httptoken.interceptor';

describe('HttptokenInterceptor', () => {
  beforeEach(() => TestBed.configureTestingModule({
    providers: [
      HttptokenInterceptor
      ]
  }));

  it('should be created', () => {
    const interceptor: HttptokenInterceptor = TestBed.inject(HttptokenInterceptor);
    expect(interceptor).toBeTruthy();
  });
});
