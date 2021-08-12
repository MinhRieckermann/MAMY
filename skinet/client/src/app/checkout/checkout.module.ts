import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CheckoutComponent } from './checkout.component';
import { CheckRoutingModule } from './check-routing.module';



@NgModule({
  declarations: [CheckoutComponent],
  imports: [
    CommonModule,
    CheckRoutingModule
  ]
})
export class CheckoutModule { }
