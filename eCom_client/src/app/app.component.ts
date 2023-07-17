import { Component, OnInit } from '@angular/core';
import { AuthService } from './Services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
<<<<<<< HEAD
export class AppComponent implements OnInit{
  title = 'Chaldal.com';
  isUserLoggedIn = false;

  constructor(private authService: AuthService) {}

  ngOnInit() {
    // Subscribe to the isAuthenticated$ observable to get the latest authentication status
    /*this.authService.isAuthenticated$.subscribe((loggedIn) => {
      this.isUserLoggedIn = loggedIn;
    });*/
  }
=======
export class AppComponent {
  title = 'Chaldal.com';
>>>>>>> 43c2f503e2e557b4cc75161e3ac23ad6959345b9
}
