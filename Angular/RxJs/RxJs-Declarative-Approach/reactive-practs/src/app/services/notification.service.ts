import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class NotificationService {
  private successMessageSubject: Subject<string> = new Subject<string>();
  successMessageAction$ = this.successMessageSubject.asObservable();

  private errorMessageSubject: Subject<string> = new Subject<string>();
  errorMessageAction$ = this.errorMessageSubject.asObservable();

  setSuccessMessage(message: string) {
    this.successMessageSubject.next(message);
  }

  setErrorMessage(message: string) {
    this.errorMessageSubject.next(message);
  }

  clearSuccessMessage() {
    this.setSuccessMessage('');
  }

  clearErrorMessage() {
    this.setErrorMessage('');
  }

  clearAllMessage() {
    this.clearSuccessMessage();
    this.clearErrorMessage();
  }

  constructor() {}
}
