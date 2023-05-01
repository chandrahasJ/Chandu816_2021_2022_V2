import { ChangeDetectionStrategy, Component, Inject } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import { IPost } from 'src/app/models/Post';
import { DeclarativePostService } from 'src/app/services/declarative-post.service';

@Component({
  selector: 'app-alt-posts',
  templateUrl: './alt-posts.component.html',
  styleUrls: ['./alt-posts.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AltPostsComponent {
  // selectedPostIdSubject = new BehaviorSubject<string>('');
  // selectedPostIdAction$ = this.postIdSubject.asObservable();
  // [class] = "{active: (selectedPostIdAction$ | async) === post.id}"

  selectedPost$ = this.postService.post;

  post$ = this.postService?.post_with_category.pipe(map((posts) => {
    return posts.filter(post => post.categoryName !== undefined)
  }));

  constructor(private postService: DeclarativePostService) {
  }

  onSelectedPost(post: IPost, event: Event){
    event.preventDefault();
    post.id && this.postService.selectPost(post.id);
    //post.id && this.postIdSubject.next(post.id);
  }
}
