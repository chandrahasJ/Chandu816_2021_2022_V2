import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoaderService {

  private loadingSubject = new BehaviorSubject<boolean>(false);
  loadingAction$ = this.loadingSubject.asObservable();

  showLoader(){
    this.loadingSubject.next(true);
  }

  hideLoader(){
    this.loadingSubject.next(false);
  }
}
