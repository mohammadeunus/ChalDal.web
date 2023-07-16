import { Component,OnInit } from '@angular/core';
import { Stock } from 'src/app/Model/stock.model';
import { StockService } from 'src/app/Services/stock.service';

@Component({
  selector: 'app-stock-list',
  templateUrl: './stock-list.component.html',
  styleUrls: ['./stock-list.component.css']
})
export class StockListComponent implements OnInit{
  
    stocks: Stock[] = [];
    constructor(private stockService: StockService) { }
  
    ngOnInit(): void {
      this.stockService.getallStocks()
        .subscribe({
            next: (stocks) => {
              this.stocks = stocks;
            },
            error: (err: any) => console.log(err)
        })      
    }

}
