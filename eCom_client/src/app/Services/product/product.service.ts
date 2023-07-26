import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/enivronment/environment';
import { Product } from '../../Model/product.model';
import { Observable } from 'rxjs';
import { UserProduct } from 'src/app/Model/user-product.model';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  baseApiUrl:string =environment.apiBaseUrl;

  constructor(private http: HttpClient) { } //to be able to talk http api we need to inject httpclient
    GetAllProduct(): Observable<Product[]>{
        return this.http.get<Product[]>(this.baseApiUrl + 'api/product');
    }
    GetAllUserProduct(): Observable<UserProduct[]>{
      return this.http.get<UserProduct[]>(this.baseApiUrl + 'api/product');
  }
}
