import { ShopService } from './../shop.service';


import { Component, OnInit } from '@angular/core';
import { IProduct } from 'src/app/shared/models/product';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.scss']
})
export class ProductDetailComponent implements OnInit {

  product:IProduct;

  constructor(private shopService:ShopService, private activateRoute:ActivatedRoute) { }

  ngOnInit(): void {

    this.loadProduct();
  }

loadProduct()
{
  this.shopService.getProduct(+this.activateRoute.snapshot.paramMap.get('id')).subscribe(product => {
    this.product=product;
  },error =>{
    console.log(error);
  });
}

}
