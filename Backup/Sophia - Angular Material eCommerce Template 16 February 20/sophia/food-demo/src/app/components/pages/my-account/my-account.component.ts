import { Router } from '@angular/router';
import { AccountService } from './../../../modules/general/shared/services/account.service';
import { first } from 'rxjs/operators';


import { Component, OnInit } from '@angular/core';
import{FormControl,FormGroup, Validators,FormBuilder} from '@angular/forms'
import {MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MyAccountDialogComponent } from './../my-account-dialog/my-account-dialog.component';


@Component({
  selector: 'app-my-account',
  templateUrl: './my-account.component.html',
  styleUrls: ['./my-account.component.sass']
})
export class MyAccountComponent implements OnInit {
  registerForm: FormGroup;
  loading = false;
  Loginsubmitted = false;
  Registersubmitted = false;
  hide = true;
  constructor(
    private dialog: MatDialog,
    private formBuider:FormBuilder,
    private router:Router,
    private accountService:AccountService
    ) { }

  ngOnInit() {  
    this.registerForm = this.formBuider.group({
      //firstName: ['', Validators.required],
     //lastName: ['', Validators.required],
     email: ['', Validators.required],
     password:['', [Validators.required, Validators.minLength(6)]]
    })
  }
  // convenience getter for easy access to form fields
get f() { return this.registerForm.controls; }




  public openProductDialog(){
    let dialogRef = this.dialog.open(MyAccountDialogComponent);
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }
 

 



}
