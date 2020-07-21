import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LayoutComponent } from '../layout/layout.component';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {

  constructor(private router: Router, public layout: LayoutComponent) { }

  ngOnInit(): void {
  }

  logout(): void{
    localStorage.removeItem('token');
    this.router.navigate(['login']);
  }

}
