import { Injectable } from '@angular/core';
import {  IUserForLoginRequest, IUserForLoginResponse, IUserForRegister } from '../models/user';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  baseUrl = environment.baseUrl;
  constructor(private http: HttpClient,private jwtHelper: JwtHelperService ) { }

  authUser(user: IUserForLoginRequest){
    return this.http.post<IUserForLoginResponse>(this.baseUrl+'/account/login', user);
    // let userArray = [];
    // let userDataFromLocalStorage = localStorage.getItem('Users');
    // if(userDataFromLocalStorage != null){
    //   userArray = JSON.parse(userDataFromLocalStorage);
    // }
    // return userArray.find((p : IUser) => p.userName == user.userName && p.password == user.password);
  }

  addUsers(user: IUserForRegister){
    return this.http.post(this.baseUrl+'/account/register', user);
    // let users = [];
    // let getUsers = localStorage.getItem('Users');
    // if(getUsers != null){
    //   users = JSON.parse(getUsers);
    //   console.log(users);
    //   users = [user,...users];
    // }
    // else{
    //   users = [user];
    // }
    // localStorage.setItem('Users', JSON.stringify(users));
  }

  isAuthenticated() : Boolean{
    const token = localStorage.getItem('token');
    return !this.jwtHelper.isTokenExpired(token!);
  }
}
