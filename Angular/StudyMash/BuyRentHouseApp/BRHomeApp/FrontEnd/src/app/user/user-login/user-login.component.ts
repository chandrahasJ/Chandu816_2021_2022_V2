import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { IUserForLoginResponse } from 'src/app/models/user';
import { AlertifyService } from 'src/app/services/alertify.service';
import { AuthService } from 'src/app/services/auth.service';


@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.css']
})
export class UserLoginComponent implements OnInit {
  loginForm! : FormGroup;

  constructor(private formBuilder : FormBuilder,
              private authService : AuthService,
              private alertify : AlertifyService,
              private router : Router) { }

  ngOnInit(): void {

    this.loginForm = this.formBuilder.group({
      userName : [null,Validators.required],
      password : [null, [Validators.required]],
    });
  }

  onSubmit(){
    console.log(this.loginForm.value);
    this.authService.authUser(this.loginForm.value).subscribe((response : IUserForLoginResponse) => {
      console.log(response)
      localStorage.setItem("token", response.token);
      localStorage.setItem("userName", response.userName);
      this.alertify.success("LoggedIn Successfully");
      this.router.navigate(['/']);
    },error => {
      console.log(error)
      this.alertify.error (error.error);
    });
  }

  get userName(){
    return this.loginForm.get('userName') as FormControl;
  }

  get password(){
    return this.loginForm.get('password') as FormControl;
  }

}
