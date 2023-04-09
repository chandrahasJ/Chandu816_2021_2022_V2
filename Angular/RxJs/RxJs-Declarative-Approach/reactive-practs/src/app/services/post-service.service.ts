import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ITodo } from '../models/ITodo';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  constructor(private http: HttpClient) {

  }

  get post_todos(){
    return this.http
            .get<{[id:number]: ITodo}>('https://project-rxjs-default-rtdb.firebaseio.com/post_todos.json');
  }
}
