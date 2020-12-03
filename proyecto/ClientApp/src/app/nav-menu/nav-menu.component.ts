import { AuthenticationService } from './../services/authentication.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  
  constructor(private authenticationService: AuthenticationService, private router: Router){
    if (this.authenticationService.currentUserValue == null) {
      this.router.navigate(['/login']);
    }
  }
  
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
  removeLocal(){
    sessionStorage.removeItem("Login");
    window.location.reload();
  }
}
