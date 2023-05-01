import { ChangeDetectionStrategy, Component } from '@angular/core';
import { BehaviorSubject, EMPTY, Subject, catchError, combineLatest, map } from 'rxjs';
import { DeclarativeCategoryService } from 'src/app/services/declarative-category.service';
import { DeclarativePostService } from 'src/app/services/declarative-post.service';

@Component({
  selector: 'app-declarative-post',
  templateUrl: './declarative-post.component.html',
  styleUrls: ['./declarative-post.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class DeclarativePostComponent {
  selectedCatergorySubject = new BehaviorSubject<string>('');
  selectedCatergoryAction$ = this.selectedCatergorySubject.asObservable();

  errorSubject = new BehaviorSubject<string>('');
  errorMessageAction$ = this.errorSubject.asObservable();

  selectedCategoryId = '';

  dPost$ = this.dPostService.post_with_category$;
  dCategory$ = this.dCategoryService.category_data$
              .pipe( catchError((error) => {
                this.errorSubject.next(error);
                return EMPTY;
              }));

  dFilterData$ = combineLatest([
    this.dPost$,
    this.selectedCatergoryAction$,
  ]).pipe(
    map(([posts, selectedCategoryId]) => {
      return posts.filter((post) => {
        return selectedCategoryId ? post.categoryId == selectedCategoryId : true;
      });
    }),
    catchError((error) => {
      this.errorSubject.next(error);
      return EMPTY;
    })
  );

  onCategoryChange(event: Event) {
    let selectedCategoryId = (event.target as HTMLSelectElement).value;
    this.selectedCatergorySubject.next(selectedCategoryId);
  }

  constructor(
    private dPostService: DeclarativePostService,
    private dCategoryService: DeclarativeCategoryService
  ) {}
}
