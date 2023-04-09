import { Component, OnInit } from '@angular/core';
import { PostService } from 'src/app/services/post-service.service';

@Component({
  selector: 'app-posts',
  templateUrl: './posts.component.html',
  styleUrls: ['./posts.component.scss']
})
export class PostsComponent implements OnInit{
  /**
   *
   */
  constructor(private postService: PostService) {
  }
  ngOnInit(): void {
     this.postService.post_todos.subscribe(data => {
      console.log(data)
     })
  }


}
