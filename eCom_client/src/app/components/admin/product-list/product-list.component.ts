import { Component,OnInit } from '@angular/core';
import { Product } from 'src/app/Model/product.model';
import { ProductService } from 'src/app/Services/product/product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit{
  products: Product[] = [];
  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    this.productService.GetAllProduct()
      .subscribe({
          next: (product) => {
            this.products = product;
            console.log(product);
          },
          error: (err: any) => console.log(err)
      })      
  }
}
 