import { Component, OnInit } from '@angular/core';
import { topProductModel } from 'src/app/Model/topProductModel';
import { TopProductService } from 'src/app/Services/topProduct/top-product.service';

@Component({
  selector: 'app-dash-board',
  templateUrl: './dash-board.component.html',
  styleUrls: ['./dash-board.component.css']
})
export class DashBoardComponent implements OnInit{
  topProducts: topProductModel[] = [];
  constructor(private topProductService: TopProductService) { }

  ngOnInit(): void {
    this.topProductService.getTopProduct()
      .subscribe({
          next: (tpPrdct) => {
            this.topProducts = tpPrdct;
            console.log(tpPrdct);
          },
          error: (err: any) => console.log(err)
      })      
  }
}
 