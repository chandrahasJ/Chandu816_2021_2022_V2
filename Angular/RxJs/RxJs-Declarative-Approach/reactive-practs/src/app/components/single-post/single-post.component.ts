import { ChangeDetectionStrategy, Component } from '@angular/core';
import { BehaviorSubject, EMPTY, catchError, tap } from 'rxjs';
import { DeclarativePostService } from 'src/app/services/declarative-post.service';

@Component({
  selector: 'app-single-post',
  templateUrl: './single-post.component.html',
  styleUrls: ['./single-post.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SinglePostComponent {
  showUpdatePost = false;
  errorSubject = new BehaviorSubject<string>('');
  errorMessageAction$ = this.errorSubject.asObservable();
  post$ = this.postService.post$
          .pipe(
            tap(() => this.showUpdatePost = false),
            catchError((error) => {
            this.errorSubject.next(error);
            return EMPTY;
          }));
  constructor(private postService: DeclarativePostService) { }

  onUpdatePost(){
    this.showUpdatePost = true;
  }
}

