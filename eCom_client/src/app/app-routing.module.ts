import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StockListComponent } from './components/Stock/stock-list/stock-list.component';

const routes: Routes = [
  {
    path: 'stocks',
    component: StockListComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
