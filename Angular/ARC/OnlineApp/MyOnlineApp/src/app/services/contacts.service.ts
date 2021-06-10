import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ContactsService {

  constructor(private httpClient : HttpClient) { }

  getUsers() : Observable<IUser>{
    return this.httpClient.get<IUser>('https://jsonplaceholder.typicode.com/users');
  }

  viewUser() : Observable<IUser>{
    return this.httpClient.get<IUser>('https://jsonplaceholder.typicode.com/users/1');
  }
}
