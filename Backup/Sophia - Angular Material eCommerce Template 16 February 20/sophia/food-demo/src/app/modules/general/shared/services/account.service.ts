
import { environment } from './../../../../../environments/environment.prod';
import { Account } from './../models/account';
import { Observable,BehaviorSubject,of } from 'rxjs';
import { HttpClient,HttpErrorResponse } from '@angular/common/http';

import { Tsconstant } from './../constant/tsconstant';
import { Jsonregisteraccount } from './../models/jsonregisteraccount';
import { Injectable } from '@angular/core';
import {catchError} from 'rxjs/operators';
import {AuthService, GoogleLoginProvider, SocialUser} from 'angularx-social-login';




@Injectable({
  providedIn: 'root'
})
export class AccountService {

  auth = false;
  private SERVER_URL = environment.SERVER_URL;
  private user;
  authState$ = new BehaviorSubject<boolean>(this.auth);
  userData$ = new BehaviorSubject<SocialUser | ResponseModel | object>(null);
  loginMessage$ = new BehaviorSubject<string>(null);
  userRole: number;

  // readonly rootUrl=Tsconstant.API_service;
  // private pagename= new BehaviorSubject<string>('home');
  // private userrole=new BehaviorSubject<number>(0);

  // private currentAccountSource = new BehaviorSubject<Account>(null); 
  // currentUser$= this.currentAccountSource.asObservable();

  // public userRole=13;
  // cast=this.pagename.asObservable();
  // castuserole=this.userrole.asObservable();


  constructor(private authService: AuthService,
    private httpClient: HttpClient) {
      authService.authState.subscribe((user: SocialUser) => {
        if (user != null) {
          this.httpClient.get(`${this.SERVER_URL}/users/validate/${user.email}`).subscribe((res: { status: boolean, user: object }) => {
            //  No user exists in database with Social Login
            if (!res.status) {
              // Send data to backend to register the user in database so that the user can place orders against his user id
              this.registerUser({
                email: user.email,
                fname: user.firstName,
                lname: user.lastName,
                password: '123456'
              }, user.photoUrl, 'social').subscribe(response => {
                if (response.message === 'Registration successful') {
                  this.auth = true;
                  this.userRole = 555;
                  this.authState$.next(this.auth);
                  this.userData$.next(user);
                }
              });
  
            } else {
              this.auth = true;
              // @ts-ignore
              this.userRole = res.user.role;
              this.authState$.next(this.auth);
              this.userData$.next(res.user);
            }
          });
  
        }
      });
     }
   //  Login User with Email and Password
   loginUser(email: string, password: string) {

    this.httpClient.post<ResponseModel>(`${this.SERVER_URL}/auth/login`, {email, password})
      .pipe(catchError((err: HttpErrorResponse) => of(err.error.message)))
      .subscribe((data: ResponseModel) => {
        if (typeof (data) === 'string') {
          this.loginMessage$.next(data);
        } else {
          this.auth = data.auth;
          this.userRole = data.role;
          this.authState$.next(this.auth);
          this.userData$.next(data);
        }
      });

  }

//  Google Authentication
  googleLogin() {
    this.authService.signIn(GoogleLoginProvider.PROVIDER_ID);
  }

  logout() {
    this.authService.signOut();
    this.auth = false;
    this.authState$.next(this.auth);
  }

  registerUser(formData: any, photoUrl?: string, typeOfUser?: string): Observable<{ message: string }> {
    const {fname, lname, email, password} = formData;
    console.log(formData);
    return this.httpClient.post<{ message: string }>(`${this.SERVER_URL}/auth/register`, {
      email,
      lname,
      fname,
      typeOfUser,
      password,
      photoUrl: photoUrl || null
    });
  }

  
}

export interface ResponseModel {
  token: string;
  auth: boolean;
  email: string;
  username: string;
  fname: string;
  lname: string;
  photoUrl: string;
  userId: number;
  type: string;
  role: number;
}