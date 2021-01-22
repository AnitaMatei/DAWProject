import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { CartItem } from 'src/app/model/CartItem';
import { Product } from 'src/app/model/Product';
import { AuthenticationService } from 'src/app/service/authentication.service';
import { CartService } from 'src/app/service/cart.service';

@Component({templateUrl: 'checkout.component.html', styleUrls:["checkout.component.css"]})
export class CheckoutComponent implements OnInit {
    cartItemsList: CartItem[] = [];
    pageNumber: number = 0;
    pageSize: number = 3;
    

    constructor(
        private router: Router,
        private authService: AuthenticationService,
        private cartService: CartService
    ) {
        if(this.isLoggedIn())
            this.getCartItemsList();
    }

    ngOnInit() {
    }

    onNextPage(){
        this.pageNumber ++;
        this.getCartItemsList();
    }

    onPreviousPage(){
        if(this.pageNumber==0)
            return;
        this.pageNumber--;
        this.getCartItemsList();
    }


    onAddQuantity(cartItem: CartItem){
        console.log(cartItem.correspondingComicBook)
        this.cartService.increaseItemQuantity(cartItem.correspondingComicBook);
        setTimeout(()=>{
            this.getCartItemsList()},500);    
    }

    onReduceQuantity(cartItem: CartItem){
        console.log(cartItem.correspondingComicBook)
            this.cartService.decreaseItemQuantity(cartItem.correspondingComicBook);
            setTimeout(()=>{
                this.getCartItemsList()},500);    

    }

    onRemoveCartItem(cartItem: CartItem){
        console.log(cartItem.correspondingComicBook)
        this.cartService.deleteCartItem(cartItem.correspondingComicBook);
        this.getCartItemsList();
    }

    getCartItemsList(){
        this.cartService.getCartItems(this.pageNumber,this.pageSize).subscribe(list =>
            {
                this.cartItemsList = [...list];
            });
    }

    onOrder(){
        this.cartService.makeOrder();
        this.router.navigate(["/"])
    }

    isLoggedIn() : boolean{
        return this.authService.currentUserValue() != null;
    }

    getTotalPrice() : number{
        let totalPrice = 0
        this.cartItemsList.forEach(item=>
                {
                    totalPrice += item.quantity*item.correspondingComicBook.price;
                }
            );
        return totalPrice;
    }
}