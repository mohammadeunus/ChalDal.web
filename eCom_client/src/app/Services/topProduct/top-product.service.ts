import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { topProductModel } from 'src/app/Model/topProductModel';
import { environment } from 'src/enivronment/environment';

@Injectable({
  providedIn: 'root'
})
export class TopProductService {

  baseApiUrl:string =environment.apiBaseUrl;
  
  constructor(private http: HttpClient) { } //to be able to talk http api we need to inject httpclient
    getTopProduct(): Observable<topProductModel[]>{
    return this.http.get<topProductModel[]>(this.baseApiUrl + 'api/AdminDashboard/GetTopProducts');
  }
}
