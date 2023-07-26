import { Component, OnInit } from '@angular/core';
import { UserProduct } from 'src/app/Model/user-product.model';
import { ProductService } from 'src/app/Services/product/product.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent  implements OnInit{

  products: UserProduct[] = [];

    
    constructor(private productService: ProductService) { }
  
    ngOnInit(): void {
      this.productService.GetAllUserProduct()
        .subscribe({
            next: (product) => {
              this.products = product;
              console.log(product);
            },
            error: (err: any) => console.log(err)
        })      
    }
  }