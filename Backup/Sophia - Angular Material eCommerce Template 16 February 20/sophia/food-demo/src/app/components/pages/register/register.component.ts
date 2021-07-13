import { CheckemailService } from './../../../modules/general/shared/services/checkemail.service';
import { Router } from '@angular/router';
import { AccountService } from './../../../modules/general/shared/services/account.service';
import { first } from 'rxjs/operators';


import { Component, OnInit } from '@angular/core';
import{FormControl,FormGroup, Validators,FormBuilder,EmailValidator} from '@angular/forms'
import {MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MyAccountDialogComponent } from './../my-account-dialog/my-account-dialog.component';
import {map} from 'rxjs/operators';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.sass'],
  providers: [EmailValidator]
})
export class RegisterComponent implements OnInit {
// declare Variable
  registrationForm: FormGroup;
  // tslint:disable-next-line:max-line-length
  private emailPattern = '(?:[a-z0-9!#$%&\'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&\'*+/=?^_`{|}~-]+)*|"(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\\\[\x01-\x09\x0b\x0c\x0e-\x7f])*")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\\])';
  comparePassword: boolean;
  registrationMessage: string;
  hide = true;

// constructor 
  constructor(
    private dialog: MatDialog,
    private fb: FormBuilder,
    private checkEmailService: CheckemailService,
    private router:Router,
    private accountService:AccountService
    ) { 
      this.registrationForm = fb.group({
        fname: ['', [Validators.required, Validators.minLength(4)]],
        lname: ['', [Validators.required, Validators.minLength(4)]],
        email: ['', [Validators.required, Validators.pattern(this.emailPattern)],
          [this.checkEmailService.emailValidate()]
        ],
        password: ['', [Validators.required, Validators.minLength(6)]],
        confirmPassword: ['', [Validators.required, Validators.minLength(6)]],
      });
    }
    get formControls() {
      return this.registrationForm.controls;
    }
  ngOnInit() {  
    this.registrationForm.valueChanges
    .pipe(map((controls) => {
      return this.formControls.confirmPassword.value === this.formControls.password.value;
    }))
    .subscribe(passwordState => {
      console.log(passwordState);
      this.comparePassword = passwordState;
    });
  }
  



  registerUser() {

    if (this.registrationForm.invalid) {
      return;
    }

    // @ts-ignore
    this.accountService.registerUser({...this.registrationForm.value}).subscribe((response: { message: string }) => {
      this.registrationMessage = response.message;
    });

    this.registrationForm.reset();
  }


  public openProductDialog(){
    let dialogRef = this.dialog.open(MyAccountDialogComponent);
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }
 


}
