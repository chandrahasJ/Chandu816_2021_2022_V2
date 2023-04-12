import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPost } from '../models/Post';
import { map, mergeMap, pipe } from 'rxjs';
import { CategoryService } from './category.service';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  constructor(private http: HttpClient, private categoryService: CategoryService) {

  }

  get post_data(){
    return this.http
            .get<{[id: string]: IPost}>('https://project-rxjs-default-rtdb.firebaseio.com/posts.json')
            .pipe(map(posts => {
              let postData: IPost[] = [];
              for (let id in posts) {
                postData.push({ ...posts[id], id})
              }
              return postData;
            }));
  }

  get post_data_with_category(){
    return this.post_data.pipe(
      mergeMap((posts) =>{
        return this.categoryService.category_data.pipe(
          map((categories) => {
            return posts.map((post) => {
              return {
                ...post,
                categoryName: categories.find((cat) => cat.id === post.categoryId)?.title
              }
            })
          })
        )
      })
    )
  }
}
