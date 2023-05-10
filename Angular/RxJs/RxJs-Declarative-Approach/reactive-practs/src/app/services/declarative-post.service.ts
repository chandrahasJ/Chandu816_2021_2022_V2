import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPost } from '../models/Post';
import { BehaviorSubject, Subject, catchError, combineLatest, map, merge, mergeMap, scan, shareReplay, throwError } from 'rxjs';
import { DeclarativeCategoryService } from './declarative-category.service';
import { CRUDAction } from '../models/CRUDAction';

@Injectable({
  providedIn: 'root',
})
export class DeclarativePostService {
  private selectedPostSubject: BehaviorSubject<string> =
    new BehaviorSubject<string>('');
  selectedPostAction$ = this.selectedPostSubject.asObservable();

  private postCRUDSubject = new Subject<CRUDAction<IPost>>();
  postCRUDAction$ = this.postCRUDSubject.asObservable();

  constructor(
    private http: HttpClient,
    private dCatergoryService: DeclarativeCategoryService
  ) {}

  addPost(post: IPost) {
    this.postCRUDSubject.next({ action: 'add', data: post });
  }

  selectPost(postId: string) {
    this.selectedPostSubject.next(postId);
  }

  post_data$ = this.http
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
      }),
      catchError(this.handleError),
      shareReplay({ bufferSize: 1, refCount: true })
    );

  post_with_category$ = combineLatest([
    this.post_data$,
    this.dCatergoryService.category_data$,
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
    }),
    catchError(this.handleError),
    shareReplay({ bufferSize: 1, refCount: true })
  );

  post$ = combineLatest([
    this.post_with_category$,
    this.selectedPostAction$,
  ]).pipe(
    map(([posts, selectedId]) => {
      return posts.find((post) => post.id === selectedId) as IPost;
    }),
    shareReplay({ bufferSize: 1, refCount: true })
  );

  all_post$ = merge(
    this.post_with_category$,
    this.postCRUDAction$
    .pipe(map((data) => {
      return [data.data];
    }))
  ).pipe(
    scan((posts, value) => {
      return [...posts, ...value];
    }, [] as IPost[])
  );

  handleError(error: Error) {
    // Write your handle logic here
    return throwError(() => {
      return 'something is not right, try after some time.';
    });
  }
}
