import { Component, Input, OnChanges } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import {ProductsService} from '../../service/products.service';
import { Product } from 'src/app/model/Product';
import { AuthenticationService } from 'src/app/service/authentication.service';
import { CartService } from 'src/app/service/cart.service';
import { Observable } from 'rxjs';

@Component({
    selector:"app-products",
     templateUrl: 'products.component.html',
                styleUrls: ['products.component.css'] })
export class ProductsComponent implements OnChanges {
    productList: Product[] = [];
    pageNumber: number = 0;
    pageSize: number = 9;
    
    @Input() searchString: string = "";

    constructor(
        private router: Router,
        private productsService: ProductsService,
        private authService: AuthenticationService,
        private cartService: CartService
    ) {
        this.getProductList();
    }

    ngOnChanges() {
        this.getProductList();
    }

    onAddToCart(product: Product){
        if(this.authService.currentUserValue() == null){
            this.router.navigate(['login'])
            return;
        }
        this.cartService.addItemToCart(product);
    }

    onNextPage(){
        this.pageNumber ++;
        this.getProductList();
    }

    onPreviousPage(){
        if(this.pageNumber==0)
            return;
        this.pageNumber--;
        this.getProductList();
    }

    getProductList(){
        this.productsService.getListOfProducts(this.searchString,this.pageNumber,this.pageSize).subscribe(list =>
            {
                this.productList = list;
            });
    }
}