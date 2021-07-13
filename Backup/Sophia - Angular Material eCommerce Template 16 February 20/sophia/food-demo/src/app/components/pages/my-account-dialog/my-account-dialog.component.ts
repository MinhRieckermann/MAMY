import { Component } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA,MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-my-account-dialog',
  templateUrl: './my-account-dialog.component.html',
  styleUrls: ['./my-account-dialog.component.sass']
})
export class MyAccountDialogComponent   {

  constructor(
    public dialog: MatDialog,
    public dialogRef: MatDialogRef<MyAccountDialogComponent>
    ) { }
  
    public close(): void {
      this.dialogRef.close();
    }

}
