import { Component, Inject } from '@angular/core';
import { map } from 'rxjs';
import { IPost } from 'src/app/models/Post';
import { DeclarativePostService } from 'src/app/services/declarative-post.service';

@Component({
  selector: 'app-alt-posts',
  templateUrl: './alt-posts.component.html',
  styleUrls: ['./alt-posts.component.scss']
})
export class AltPostsComponent {
  post$ = this.postService?.post_with_category.pipe(map((posts) => {
    return posts.filter(post => post.categoryName !== undefined)
  }));
  /**
   *
   */
  constructor(private postService: DeclarativePostService) {

  }

  onSelectedPost(post: IPost, event: Event){
    event.preventDefault();
    console.log(post);
  }
}
