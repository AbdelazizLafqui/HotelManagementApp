import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserLoginItem } from '../../../shared/Items/userLoginItem';
import { UserRegisterItem } from '../../../shared/Items/userRegisterItem';
import { User } from '../../../shared/models/User';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http: HttpClient,private router: Router) { }


  login(userLoginItem: UserLoginItem) {
    return this.http.post<User>('api/auth/login', userLoginItem).subscribe({
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
    return this.http.post<User>('api/auth/register', userRegisterItem).subscribe({
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

}
