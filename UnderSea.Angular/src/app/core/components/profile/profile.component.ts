import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LayoutComponent } from '../layout/layout.component';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {

  constructor(private router: Router, public layout: LayoutComponent, private auth: AuthService) { }

  ngOnInit(): void {
  }

  logout(): void {
    this.auth.logout()
    .subscribe(_ => this.router.navigate(['login']));
  }

  navigateToCountry(): void {
    this.router.navigate(['main']);
  }
}
