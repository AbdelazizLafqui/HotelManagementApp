import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable, OnDestroy } from '@angular/core';
import { UserLoginItem } from '../../../shared/Items/userLoginItem';
import { UserRegisterItem } from '../../../shared/Items/userRegisterItem';
import { User } from '../../../shared/models/User';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private loginSubscription?: Subscription;
  private registerSubscription?: Subscription;
  
  constructor(private http: HttpClient,private router: Router) { }


  login(userLoginItem: UserLoginItem) {
    this.loginSubscription = this.http.post<User>('api/auth/login', userLoginItem).subscribe({
      next: (response) => {
        const token = response.token
        localStorage.setItem('auth_token', token);
      },
      error: (error: HttpErrorResponse) => {
        alert(error.error.title);
      },
      complete: () =>{
        this.router.navigate(['/home']);
      }
    });
  }

  register(userRegisterItem: UserRegisterItem) {
    this.registerSubscription = this.http.post<User>('api/auth/register', userRegisterItem).subscribe({
      next: (response) => {
        const token = response.token
        localStorage.setItem('auth_token', token);
      },
      error: (error: HttpErrorResponse) => {
        alert(error.error.title);
      },
      complete: () =>{
        this.router.navigate(['/home']);
      }

    });
  }

  unsubscribe(): void {
    this.loginSubscription?.unsubscribe();
    this.registerSubscription?.unsubscribe();
  }

}
