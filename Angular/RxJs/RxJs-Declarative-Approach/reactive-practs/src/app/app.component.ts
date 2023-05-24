import { ChangeDetectionStrategy, Component } from '@angular/core';
import { LoaderService } from './services/loader.service';
import { NotificationService } from './services/notification.service';
import { tap } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  changeDetection : ChangeDetectionStrategy.OnPush
})
export class AppComponent {
  title = 'reactive-practs';
  showLoader$ = this.loaderService.loadingAction$;
  errorMessage$ = this.notificationService
                      .errorMessageAction$.pipe(
                        tap((message)=>{
                          message && this.hideTheMessage()
                        })
                      );
  successMessage$ = this.notificationService
                        .successMessageAction$.pipe(
                          tap((message)=>{
                            message && this.hideTheMessage()
                          })
                        );

  hideTheMessage(){
    setTimeout(
      () => this.notificationService.clearAllMessage(),
      4000
    )
  }

  constructor(private loaderService: LoaderService,
              private notificationService: NotificationService) { }
}
