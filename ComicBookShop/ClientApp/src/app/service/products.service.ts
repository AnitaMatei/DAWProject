import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import {Product} from '../model/Product';


@Injectable({ providedIn: 'root' })
export class ProductsService {

    constructor(private http: HttpClient) {
    }

    public getListOfProducts(name:string, pageNumber:number, pageSize:number): Observable<Product[]>{
        return this.http.get<Product[]>(environment.API_URL+'comicbook?name='+name.replace(' ','%20')+'&pageSize='+pageSize+'&pageNumber='+pageNumber);
    }


}