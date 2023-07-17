import { Component, OnInit } from '@angular/core';
import { AuthService } from './Services/auth.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  isUserLoggedIn = false;

  constructor(private modalService: NgbModal,private authService: AuthService) {}
  
  public open(modal: any): void {
    this.modalService.open(modal);
  }
  ngOnInit() {
    // Subscribe to the isAuthenticated$ observable to get the latest authentication status
    /*this.authService.isAuthenticated$.subscribe((loggedIn) => {
      this.isUserLoggedIn = loggedIn;
    });*/
  } 
}
