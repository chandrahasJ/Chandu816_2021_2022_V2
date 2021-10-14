import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { AlertifyService } from './alertify.service';
import { Observable, of, throwError } from 'rxjs';
import { catchError, concatMap, retryWhen } from 'rxjs/operators';
import { ErrorCode } from '../enums/ErrorCode';

@Injectable()
export class HttperrorsInterceptor implements HttpInterceptor {

  constructor(private alertify : AlertifyService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      retryWhen(
        error =>
          this.retryErrorRequest(error, 10)
      ),
      catchError((error : HttpErrorResponse) => {
        console.log('Http interceptor detected.')
        console.log(error)
        const errorMessage = this.setError(error);
        this.alertify.error (errorMessage);
        return throwError(errorMessage);
      })
    );
  }

  retryErrorRequest(error : Observable<unknown>, retryCount : number): Observable<unknown>{
    return error.pipe(
          concatMap((checkError: unknown, count : number) => {
            const err = checkError as HttpErrorResponse;
              if(count <= retryCount){
                  switch(err.status){
                    case ErrorCode.serverDown :
                       return of(err);
                  }
              }
              return throwError(err);
          })
    );
  }

  setError(error : HttpErrorResponse) : string{
    let errorMessage = 'Unknown error occured.';
    if(error.error instanceof ErrorEvent)
    {
      //Client Side
      errorMessage = error.error.message;
      console.log("CS " +errorMessage);
    }
    else{
      //Server Side
      switch (error.status) {
        case ErrorCode.BadRequest:
          errorMessage = error.message;
          break;
        case ErrorCode.InternalError:
          errorMessage = error.message;
            break;
        case ErrorCode.UnAuthorized:
          errorMessage = error.message;
              break;
        case ErrorCode.serverDown:
          errorMessage = error.message;
                break;
        case ErrorCode.BadRequest:
          errorMessage = error.message;
        break;

        default:
          errorMessage = error.error.message === undefined ? errorMessage : error.message;
          break;
      }
    }
    console.log(error.error)
    console.log(error.status)
    return errorMessage;
  }

}
