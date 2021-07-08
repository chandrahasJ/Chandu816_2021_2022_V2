import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
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
    const token = this.authService.authUser(this.loginForm.value);
    if(token){
      localStorage.setItem("token", token.userName);      
      this.alertify.success("LoggedIn Successfully");
      this.router.navigate(['/']);
    }
    else{
      this.alertify.error ("username or password is wrong.");
    }
  }

  get userName(){
    return this.loginForm.get('userName') as FormControl;
  }

  get password(){
    return this.loginForm.get('password') as FormControl;
  }

}
