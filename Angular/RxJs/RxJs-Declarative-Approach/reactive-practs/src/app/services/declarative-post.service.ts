import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPost } from '../models/Post';
import { map, mergeMap } from 'rxjs/operators';
import { CategoryService } from './category.service';

@Injectable({
  providedIn: 'root'
})
export class DeclarativePostService {

  constructor(private http: HttpClient) { }

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
}
