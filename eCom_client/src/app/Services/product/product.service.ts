import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/enivronment/environment';
import { Product } from '../../Model/product.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  baseApiUrl:string =environment.apiBaseUrl;

  constructor(private http: HttpClient) { } //to be able to talk http api we need to inject httpclient
    GetAllProduct(): Observable<Product[]>{
    return this.http.get<Product[]>(this.baseApiUrl + 'api/product');
  }
}
