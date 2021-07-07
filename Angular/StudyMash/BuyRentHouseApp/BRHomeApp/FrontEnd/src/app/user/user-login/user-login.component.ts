import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';


@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.css']
})
export class UserLoginComponent implements OnInit {
  loginForm! : FormGroup;

  constructor() { }

  ngOnInit(): void {
    this.loginForm = new FormGroup({
      userName : new FormControl(null,Validators.required),
      email : new FormControl(null,[Validators.required, Validators.email]),
      password : new FormControl(null, [Validators.required, Validators.minLength(8)]),
    });
  }

  onSubmit(){
    console.log(this.loginForm);
  }

  get userName(){
    return this.loginForm.get('userName') as FormControl;
  }

  get email(){
    return this.loginForm.get('email') as FormControl;
  }

  get password(){
    return this.loginForm.get('password') as FormControl;
  }

}
