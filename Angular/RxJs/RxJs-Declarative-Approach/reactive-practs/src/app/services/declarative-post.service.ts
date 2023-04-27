import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPost } from '../models/Post';
import { BehaviorSubject, combineLatest, map, mergeMap } from 'rxjs';
import { DeclarativeCategoryService } from './declarative-category.service';

@Injectable({
  providedIn: 'root',
})
export class DeclarativePostService {
  private selectedPostSubject: BehaviorSubject<string> =
    new BehaviorSubject<string>('');
  selectedPostAction$ = this.selectedPostSubject.asObservable();

  constructor(
    private http: HttpClient,
    private dCatergoryService: DeclarativeCategoryService
  ) {}

  selectPost(postId: string) {
    console.log(postId);
    this.selectedPostSubject.next(postId);
  }

  get post() {
    return combineLatest([
      this.post_with_category,
      this.selectedPostAction$,
    ]).pipe(
      map(([posts, selectedId]) => {
        return posts.find((post) => post.id === selectedId) as IPost;
      })
    );
  }

  get post_data() {
    return this.http
      .get<{ [id: string]: IPost }>(
        'https://project-rxjs-default-rtdb.firebaseio.com/posts.json'
      )
      .pipe(
        map((posts) => {
          let postData: IPost[] = [];
          for (let id in posts) {
            postData.push({ ...posts[id], id });
          }
          return postData;
        })
      );
  }

  get post_with_category() {
    return combineLatest([
      this.post_data,
      this.dCatergoryService.category_data,
    ]).pipe(
      map(([posts, categories]) => {
        return posts.map((post) => {
          return {
            ...post,
            categoryName: categories.find(
              (category) => category.id == post.categoryId
            )?.title,
          } as IPost;
        });
      })
    );
  }
}
