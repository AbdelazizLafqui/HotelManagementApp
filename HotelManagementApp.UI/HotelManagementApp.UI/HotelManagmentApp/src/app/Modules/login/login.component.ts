import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from './Services/login.service';
import { UserLoginItem } from '../../shared/Items/userLoginItem';
import { UserRegisterItem } from '../../shared/Items/userRegisterItem';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.sass'
})
export class LoginComponent implements OnInit{

  registerFormLabel : string='New User? Register';
  showForm: boolean = true;
  loginForm!: FormGroup;
  registerForm!: FormGroup;

  constructor(private route:Router ,
    private loginService: LoginService,
    private fb: FormBuilder){

  }

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      email: new FormControl({ value: '', disabled: false },{ validators: [Validators.required, Validators.email]}),
      password: new FormControl({ value: '', disabled: false },{ validators: [Validators.required]}),
    })
    this.registerForm = this.fb.group({
      firstName: new FormControl({ value: '', disabled: false },{ validators: [Validators.required]}),
      lastName: new FormControl({ value: '', disabled: false },{ validators: [Validators.required]}),
      email: new FormControl({ value: '', disabled: false },{ validators: [Validators.required, Validators.email]}),
      password: new FormControl({ value: '', disabled: false },{ validators: [Validators.required]}),
    })
  }

  
  showRegisterForm() {
    this.showForm = !this.showForm;
    if(!this.showForm){
      this.registerFormLabel = 'Already a User, Login';
    }
    else{
      this.registerFormLabel ='New User? Register';
    }
  }

  login()
  {
    const user:  UserLoginItem = {
      email: this.loginForm.get('email')?.value,
      password: this.loginForm.get('password')?.value,
    };

    this.loginService.login(user);
  }
  register()
  {
    const user:  UserRegisterItem = {
      firstName: this.registerForm.get('firstName')?.value,
      lastName: this.registerForm.get('lastName')?.value,
      email: this.registerForm.get('email')?.value,
      password: this.registerForm.get('password')?.value,
    };

    this.loginService.register(user);
  }
}
