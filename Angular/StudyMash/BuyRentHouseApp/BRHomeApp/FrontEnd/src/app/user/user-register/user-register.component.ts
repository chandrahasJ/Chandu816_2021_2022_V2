import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import CustomValidations from 'src/app/helper/validation';

@Component({
  selector: 'app-user-register',
  templateUrl: './user-register.component.html',
  styleUrls: ['./user-register.component.css']
})
export class UserRegisterComponent implements OnInit {

  registerationForm!: FormGroup;
  regexpNumber = /[0-9\+\-\ ]/;
  constructor() { }

  ngOnInit(): void {
    this.registerationForm = new FormGroup({
      userName : new FormControl(null,Validators.required),
      email : new FormControl(null,[Validators.required, Validators.email]),
      password : new FormControl(null, [Validators.required, Validators.minLength(8)]),
      confirmPassword : new FormControl(null, [Validators.required]),
       mobile : new FormControl(null,[Validators.required, Validators.maxLength(10)])
    }, {
      validators : CustomValidations.match('password','confirmPassword')
    });
  }

  get userName(){
    return this.registerationForm.get('userName') as FormControl;
  }

  get email(){
    return this.registerationForm.get('email') as FormControl;
  }

  get password(){
    return this.registerationForm.get('password') as FormControl;
  }

  get confirmPassword(){
    return this.registerationForm.get('confirmPassword') as FormControl;
  }

  get mobile(){
    return this.registerationForm.get('mobile') as FormControl;
  }

  onSubmit(){
    console.log(this.registerationForm);
  }

}
