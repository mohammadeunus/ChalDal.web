import { Component,OnInit } from '@angular/core';
import { Stock } from 'src/app/Model/stock.model';

@Component({
  selector: 'app-stock-list',
  templateUrl: './stock-list.component.html',
  styleUrls: ['./stock-list.component.css']
})
export class StockListComponent implements OnInit{
  
    stocks: Stock[] = [];
    constructor() { }
  
    ngOnInit(): void {
    }

}
