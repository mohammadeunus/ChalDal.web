import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private isAuthenticatedSubject = new BehaviorSubject<boolean>(false);
  public isAuthenticated$ = this.isAuthenticatedSubject.asObservable();

  // Other methods related to login, logout, etc.

  public login() {
    // ... Logic to handle user login
    this.isAuthenticatedSubject.next(true);
  }

  public logout() {
    // ... Logic to handle user logout
    this.isAuthenticatedSubject.next(false);
  }
}
