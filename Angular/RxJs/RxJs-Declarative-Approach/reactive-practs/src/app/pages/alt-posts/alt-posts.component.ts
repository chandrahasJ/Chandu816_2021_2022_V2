import { ChangeDetectionStrategy, Component, Inject, OnInit } from '@angular/core';
import { BehaviorSubject, map, tap } from 'rxjs';
import { IPost } from 'src/app/models/Post';
import { DeclarativePostService } from 'src/app/services/declarative-post.service';
import { LoaderService } from 'src/app/services/loader.service';

@Component({
  selector: 'app-alt-posts',
  templateUrl: './alt-posts.component.html',
  styleUrls: ['./alt-posts.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AltPostsComponent implements OnInit {
  // selectedPostIdSubject = new BehaviorSubject<string>('');
  // selectedPostIdAction$ = this.postIdSubject.asObservable();
  // [class] = "{active: (selectedPostIdAction$ | async) === post.id}"

  selectedPost$ = this.postService.post$;

  post$ = this.postService?.post_with_category$.pipe(
    tap(() => this.loaderService.hideLoader()),
    map((posts) => {
    return posts.filter(post => post.categoryName !== undefined)
  }));

  constructor(private postService: DeclarativePostService,
              private loaderService:LoaderService) {
  }

  ngOnInit(): void {
    this.loaderService.showLoader();
  }

  onSelectedPost(post: IPost, event: Event){
    event.preventDefault();
    post.id && this.postService.selectPost(post.id);
    //post.id && this.postIdSubject.next(post.id);
  }
}
