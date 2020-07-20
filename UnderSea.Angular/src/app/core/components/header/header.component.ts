import { Component, OnInit } from '@angular/core';

import { LayoutService } from '../../services/layout.service';
import { tap, catchError } from 'rxjs/operators';
import { UnitViewModel, MainPageViewModel } from '../../../shared/index';
import { LayoutComponent } from '../layout/layout.component';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  everything: MainPageViewModel;
  
  constructor(private service: LayoutService, public layout: LayoutComponent) { }

  ngOnInit(): void {
    this.service.getEverything().pipe(
      tap(res => this.everything = res),
      catchError(error => console.assert)
    ).subscribe();

  }

}
