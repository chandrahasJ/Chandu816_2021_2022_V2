import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AlertifyService } from './alertify.service';

@Injectable()
export class HttperrorsInterceptor implements HttpInterceptor {

  constructor(private alertify : AlertifyService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError((error : HttpErrorResponse) => {
        console.log('Http interceptor detected.')
        console.log(error)
        const errorMessage = this.setError(error);
        this.alertify.error (errorMessage);
        return throwError(errorMessage);
      })
    );
  }

  setError(error : HttpErrorResponse) : string{
    let errorMessage = 'Unknown error occured.';
    if(error.error instanceof ErrorEvent)
    {
      //Client Side
      errorMessage = error.error.message;
    }
    else{
      //Server Side
      if(error.status != 0){
        errorMessage = error.error.errorMessage;
      }
    }
    return errorMessage;
  }

}
