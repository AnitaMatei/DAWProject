import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import {CartItem} from '../model/CartItem';
import { Product } from '../model/Product';


@Injectable({ providedIn: 'root' })
export class CartService {

    constructor(private http: HttpClient) {
    }

    public addItemToCart(product : Product){
        return this.http.post<any>(environment.API_URL+'cart',
        {
            "title": product.title
        }
        ).subscribe(
            error => {
                console.log(error);
            }
        );
    }
    
    public increaseItemQuantity(product : Product){
        return this.http.put<any>(environment.API_URL+'cart/incQuantity',
        {
            "title": product.title
        }
        ).subscribe(
            error => {
                console.log(error);
            }
        );
    }
    public decreaseItemQuantity(product : Product){
        return this.http.put<any>(environment.API_URL+'cart/decQuantity',
        {
            "title": product.title
        }
        ).subscribe(
            error => {
                console.log(error);
            }
        );
    }
    public deleteCartItem(product : Product){
        return this.http.delete<any>(environment.API_URL+'cart/'+product.title).subscribe(
            error => {
                console.log(error);
            }
        );
    }

    public makeOrder(){
        return this.http.post<any>(environment.API_URL+'order',
        {
            "details": "dsa"
        }
        ).subscribe(
            error => {
                console.log(error);
            }
        );
    }

    public getCartItems(pageNumber, pageSize) : Observable<CartItem[]>{
        return this.http.get<CartItem[]>(environment.API_URL+'cart?'+'pageSize='+pageSize+'&pageNumber='+pageNumber);
    }
    
    public getAllCartItems():Observable<CartItem[]>{
        return this.http.get<CartItem[]>(environment.API_URL+'cart?'+'pageSize=10&pageNumber=0')
    }

}