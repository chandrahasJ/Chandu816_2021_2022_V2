import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../interface/User';

@Injectable({
  providedIn: 'root'
})
export class ContactsService {

  constructor(private httpClient : HttpClient) { }

  getUsers() : Observable<User []>{
    return this.httpClient.get<User []>('https://jsonplaceholder.typicode.com/users');
  }

  viewUser() : Observable<User>{
    return this.httpClient.get<User>('https://jsonplaceholder.typicode.com/users/1');
  }
}
