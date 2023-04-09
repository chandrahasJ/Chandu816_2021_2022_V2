import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { IPost } from 'src/app/models/Post';
import {  PostService } from 'src/app/services/post-service.service';

@Component({
  selector: 'app-posts',
  templateUrl: './posts.component.html',
  styleUrls: ['./posts.component.scss']
})
export class PostsComponent implements OnInit, OnDestroy{
  posts: IPost[] = [];
  postsSubscription! : Subscription;
  /**
   *
   */
  constructor(private postService: PostService) {
  }

  ngOnDestroy(): void {
    this.postsSubscription &&  this.postsSubscription.unsubscribe();
  }

  ngOnInit(): void {
    this.postsSubscription =  this.postService.post_data.subscribe(data => {
        this.posts = data;
     })
  }




}
