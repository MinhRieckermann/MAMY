import { ShopService } from './../shop.service';


import { Component, OnInit } from '@angular/core';
import { IProduct } from 'src/app/shared/models/product';
import { ActivatedRoute } from '@angular/router';
import { BreadcrumbService } from 'xng-breadcrumb';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.scss']
})
export class ProductDetailComponent implements OnInit {

  product:IProduct;

  constructor(private shopService:ShopService, private activateRoute:ActivatedRoute,private  bcService: BreadcrumbService) { 
      this.bcService.set('@productDetails','');
    }

  ngOnInit(): void {

    this.loadProduct();
  }

loadProduct()
{
  this.shopService.getProduct(+this.activateRoute.snapshot.paramMap.get('id')).subscribe(product => {
    this.product=product;
    this.bcService.set('@productDetails',product.name);
  },error =>{
    console.log(error);
  });
}

}
