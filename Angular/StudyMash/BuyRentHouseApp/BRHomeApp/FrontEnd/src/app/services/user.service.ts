import { Injectable } from '@angular/core';
import { IUser } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor() { }

  addUsers(user: IUser){
    let users = [];
    let getUsers = localStorage.getItem('Users');
    if(getUsers != null){
      users = JSON.parse(getUsers);
      console.log(users);
      users = [user,...users];
    }
    else{
      users = [user];
    }
    localStorage.setItem('Users', JSON.stringify(users));
  }
}
