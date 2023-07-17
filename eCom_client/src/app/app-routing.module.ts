import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StockListComponent } from './components/admin/stock-list/stock-list.component';
import { AdminComponent } from './components/admin/admin.component';
import { DashBoardComponent } from './components/admin/dash-board/dash-board.component';

const routes: Routes = [
  {
    path: 'admin',
    component: AdminComponent,
    children: [
      { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
      { path: 'dashboard', component: DashBoardComponent },
      { path: 'stock', component: StockListComponent },  
      // Add more admin routes as needed
    ],
  },


  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
