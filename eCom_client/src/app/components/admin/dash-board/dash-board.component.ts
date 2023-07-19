import { Component, OnInit } from '@angular/core';
import { topProductModel } from 'src/app/Model/topProductModel';
import { TopProductService } from 'src/app/Services/topProduct/top-product.service';

@Component({
  selector: 'app-dash-board',
  templateUrl: './dash-board.component.html',
  styleUrls: ['./dash-board.component.css']
})
export class DashBoardComponent implements OnInit {
  topProducts: topProductModel[] = [];
  barChartData: any[] = [];  
  barChartLabels: string[] = [];
  barChartOptions: any = {
    responsive: true,
    scales: {
      yAxes: [{
        ticks: {
          beginAtZero: true
        }
      }]
    }
  };
  barChartLegend = true;
  barChartType = 'bar';

  constructor(private topProductService: TopProductService) {}

  ngOnInit(): void {
    this.topProductService.getTopProduct().subscribe({
      next: (tpPrdct) => {
        this.topProducts = tpPrdct;
        console.log(tpPrdct);

        // Prepare data for the chart
        this.barChartData = [
          { data: this.topProducts.map((product) => product.popularityCount), label: 'Product Hits' },
        ];
        this.barChartLabels = this.topProducts.map((product) => product.name);
      },
      error: (err: any) => console.log(err),
    });
  }
}
