import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPost } from '../models/Post';
import { BehaviorSubject, Observable, Subject, catchError, combineLatest, concatMap, map, merge, mergeMap, of, scan, share, shareReplay, throwError } from 'rxjs';
import { DeclarativeCategoryService } from './declarative-category.service';
import { CRUDAction } from '../models/CRUDAction';

@Injectable({
  providedIn: 'root',
})
export class DeclarativePostService {
  url = 'https://project-rxjs-default-rtdb.firebaseio.com/posts.json';
  postPatchDeleteURL = 'https://project-rxjs-default-rtdb.firebaseio.com/posts/';
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

  updatePost(post: IPost) {
    this.postCRUDSubject.next({ action: 'update', data: post });
  }

  deletePost(post: IPost) {
    this.postCRUDSubject.next({ action: 'delete', data: post });
  }

  selectPost(postId: string) {
    this.selectedPostSubject.next(postId);
  }

  post_data$ = this.http.get<{ [id: string]: IPost }>(this.url).pipe(
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


  all_post$ = merge(
    this.post_with_category$,
    this.postCRUDAction$.pipe(
      concatMap((postAction) =>
        this.savePost(postAction).pipe(
          map((post) => ({
              ...postAction,
              data: post,
          }))
        )
      )
    )
  ).pipe(
    scan((posts, value) => {
      return this.modifyPosts(posts, value);
    }, [] as IPost[]),
    shareReplay({ bufferSize: 1, refCount: true })
  );

  savePost(postAction: CRUDAction<IPost>) {
    let postObservable$! : Observable<IPost>;

    if (postAction.action === 'add') {
      postObservable$! = this.addPostToServer(postAction.data)
    }

    if (postAction.action === 'update') {
      postObservable$! = this.updatePostToServer(postAction.data)
    }

    if (postAction.action === 'delete') {
      return this.deletePostToServer(postAction.data)
                 .pipe(map(post => postAction.data))
    }

    return postObservable$.pipe(
      concatMap(post =>
        this.dCatergoryService.category_data$.pipe(
          map((categories) => {
            return {
              ...post,
              categoryName: categories
                            .find((x) =>
                                x.id == post.categoryId)?.title
            };
          })
        )
      )
    );
  }

  addPostToServer(post: IPost) {
    return this.http.post<{ name: string }>(this.url, post).pipe(
      map((id) => {
        return {
          ...post,
          id: id.name,
        };
      })
    );
  }

  updatePostToServer(post: IPost) {
    return this.http.patch<IPost>(this.postPatchDeleteURL+`${post.id}.json`, post);
  }

  deletePostToServer(post: IPost) {
    return this.http.delete(this.postPatchDeleteURL+`${post.id}.json`);
  }

  modifyPosts(posts: IPost[], value: IPost[] | CRUDAction<IPost>): IPost[] {
    if (!(value instanceof Array)) {
      if (value.action === 'add') {
        return [...posts, value.data];
      }
      if (value.action === 'update') {
        return posts.map(post =>
          post.id === value.data.id ? value.data : post);
      }
      if (value.action === 'delete') {
        return posts.filter(post => post.id !== value.data.id);
      }
    } else {
      return value;
    }
    return posts;
  }

  post$ = combineLatest([
    this.all_post$,
    this.selectedPostAction$,
  ]).pipe(
    map(([posts, selectedId]) => {
      return posts.find((post) => post.id === selectedId) as IPost;
    }),
    shareReplay({ bufferSize: 1, refCount: true })
  );

  handleError(error: Error) {
    // Write your handle logic here
    return throwError(() => {
      return 'something is not right, try after some time.';
    });
  }
}
