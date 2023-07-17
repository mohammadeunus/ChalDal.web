import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { StockListComponent } from './components/admin/stock-list/stock-list.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { HeaderComponent } from './components/shared/header/header.component';
import { FooterComponent } from './components/shared/footer/footer.component';
import { SideNavBarComponent } from './components/admin/side-nav-bar/side-nav-bar.component';
import { AdminComponent } from './components/admin/admin.component';
import { UserComponent } from './components/user/user.component';
import { DashBoardComponent } from './components/admin/dash-board/dash-board.component';
import { AdminHeaderComponent } from './components/admin/admin-header/admin-header.component';
 

@NgModule({
  declarations: [
    AppComponent,
    StockListComponent,
    HeaderComponent,
    FooterComponent,
    SideNavBarComponent,
    AdminComponent,
    UserComponent,
    DashBoardComponent,
    DashBoardComponent,
    AdminHeaderComponent,  
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
