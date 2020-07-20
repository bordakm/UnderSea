import { Component, OnInit } from '@angular/core';

import { LayoutService } from '../../services/layout.service';
import { IUnitViewModel, MainPageViewModel } from 'src/app/shared';
import { tap, catchError } from 'rxjs/operators';


@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss']
})
export class LayoutComponent implements OnInit {

  everything: MainPageViewModel;
  
  constructor(private service: LayoutService) { }

  ngOnInit(): void {
    this.service.getEverything().pipe(
      tap(res => this.everything = res),
      catchError(error => console.assert)
    ).subscribe();
  }

}
