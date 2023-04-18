import { ChangeDetectionStrategy, Component } from '@angular/core';
import { map } from 'rxjs';
import { DeclarativeCategoryService } from 'src/app/services/declarative-category.service';
import { DeclarativePostService } from 'src/app/services/declarative-post.service';

@Component({
  selector: 'app-declarative-post',
  templateUrl: './declarative-post.component.html',
  styleUrls: ['./declarative-post.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class DeclarativePostComponent {
  selectedCategoryId = '';

  dPost$ = this.dPostService.post_with_category;
  dCategory$ = this.dCategoryService.category_data;

  dFilterData$ = this.dPost$.pipe(
    map((posts) => {
      return posts.filter((post) =>
        this.selectedCategoryId
          ? post.categoryId === this.selectedCategoryId
          : true
      );
    })
  );

  onCategoryChange(event: Event) {
    let selectedCategoryId = (event.target as HTMLSelectElement).value;
    this.selectedCategoryId = selectedCategoryId;
    console.log(this.selectedCategoryId);
  }

  constructor(
    private dPostService: DeclarativePostService,
    private dCategoryService: DeclarativeCategoryService
  ) {}
}
