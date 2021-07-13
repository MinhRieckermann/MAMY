
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxSpinnerModule } from 'ngx-spinner';
import { NgxImgZoomModule } from 'ngx-img-zoom';

import { MainComponent } from './components/main/main.component';


import { AppRoutingModule } from './app-routing.module';
import { ShopModule } from './components/shop/shop.module';
import { SharedModule } from './components/shared/shared.module';

import { HashLocationStrategy, LocationStrategy } from '@angular/common';
import { ColorOptionsComponent } from './components/color-options/color-options.component';


import { MaterialModule } from './modules/general/shared/material/material.module';
import {AuthServiceConfig, GoogleLoginProvider, SocialLoginModule,AuthService} from 'angularx-social-login';
const config = new AuthServiceConfig([
  {
    id: GoogleLoginProvider.PROVIDER_ID,
    provider: new GoogleLoginProvider('799705726167-vn6184fsovmps0kpbg5c7jabv15r3ias.apps.googleusercontent.com')
  }

]);
export function provideConfig() {
  return config;
}

@NgModule({
  declarations: [
    AppComponent,
    MainComponent,
    ColorOptionsComponent
  ],
  imports: [
    NgxSpinnerModule,
    BrowserModule,
    SharedModule,
    ShopModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    NgxImgZoomModule,
    MaterialModule

  ],
  providers: [
    AuthService,
    {
     useClass: HashLocationStrategy,
     provide: AuthServiceConfig,
      useFactory: provideConfig,
      
    }
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }
