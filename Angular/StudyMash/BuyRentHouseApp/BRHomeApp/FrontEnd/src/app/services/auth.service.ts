import { Injectable } from '@angular/core';
import { IUser } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor() { }

  authUser(user: IUser){
    let userArray = [];
    let userDataFromLocalStorage = localStorage.getItem('Users');
    if(userDataFromLocalStorage != null){
      userArray = JSON.parse(userDataFromLocalStorage);
    }
    return userArray.find((p : IUser) => p.userName == user.userName && p.password == user.password);
  }
}
