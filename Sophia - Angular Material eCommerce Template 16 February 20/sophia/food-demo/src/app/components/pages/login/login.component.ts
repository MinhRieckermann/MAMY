import { UserService } from './../../shared/services/user.service';
import { Component, OnInit } from '@angular/core';
import {NgForm} from '@angular/forms';
import {AuthService} from 'angularx-social-login';
import {ActivatedRoute, Router} from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.sass']
})
export class LoginComponent implements OnInit {
  email: string;
  password: string;
  loginMessage: string;
  userRole: number;
  userData$;
  constructor(
    private authService: AuthService,
              private router: Router,
              private userService: UserService,
              private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    // this.userService.authState$.subscribe(authState => {
    //   // if (authState) {
    //   //   console.log(authState)
    //   //   this.router.navigateByUrl(this.route.snapshot.queryParams.returnUrl || '/home');

    //   // } else {
    //     this.router.navigateByUrl('/login');
    //   //}
    // });
  }

  signInWithGoogle() {
    this.userService.googleLogin();
  }

//   login(myform: NgForm) {
//     const email = this.email;
//     const password = this.password;
//     console.log(this.email);
//     console.log(this.password);

//     if (myform.invalid) {
//       return;
//     }
// else
// {console.log(myform.value)
//  // myform.reset();
//     this.userService.loginUser(email, password);
//     console.log(this.userData$);

//     this.userService.loginMessage$.subscribe(msg => {
//       this.loginMessage = msg;
//       console.log(this.loginMessage)
//       setTimeout(() => {
//         this.loginMessage = '';
//       }, 2000);
      
//     });
//     this.router.navigateByUrl('/home');

//   }
//   }
login(data)
{
  console.log(data)
      const email = this.email;
    const password = this.password;
    console.log(email);
    console.log(password);
    this.userService.loginUser(email, password);
    this.userService.userData$.subscribe(user=>
      {
        console.log(user)
      }

    )
    this.userService.loginMessage$.subscribe(msg=>{
      this.loginMessage=msg;
      console.log(this.loginMessage)
    }

    )
    
}

}
