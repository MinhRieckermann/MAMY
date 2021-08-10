import { NotFoundComponent } from './core/not-found/not-found.component';
import { ServerErrorComponent } from './core/server-error/server-error.component';
import { TestErrorComponent } from './core/test-error/test-error.component';
import { ProductDetailComponent } from './shop/product-detail/product-detail.component';
import { ShopComponent } from './shop/shop.component';
import { HomeComponent } from './home/home/home.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  {path:'',component:HomeComponent,data:{breadcrumb:'Home'}},
  {path:'test-error',component:TestErrorComponent,data:{breadcrumb:'Test Errors'}},
  {path:'server-error',component:ServerErrorComponent,data:{breadcrumb:'Server Error'}},
  {path:'not-found',component:NotFoundComponent,data:{breadcrumb:'Not Found'}},
  {path:'shop',loadChildren:() => import('./shop/shop.module').then(mod => mod.ShopModule),data:{breadcrumb:'Shop'}},
  {path:'basket',loadChildren:() => import('./basket/basket.module').then(mod => mod.BasketModule),data:{breadcrumb:'Basket'}},
  {path:'**',redirectTo:'not-found',pathMatch:'full'},
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
