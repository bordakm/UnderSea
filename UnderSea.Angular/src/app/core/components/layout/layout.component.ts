import { Component, OnInit } from '@angular/core';

import { LayoutService } from '../../services/layout.service';
import { IUnitViewModel } from 'src/app/shared';
import { tap, catchError } from 'rxjs/operators';


@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss']
})
export class LayoutComponent implements OnInit {

  units: IUnitViewModel[];

  constructor(private service: LayoutService) { }

  ngOnInit(): void {
    this.service.getUnits().pipe(
      tap(res => this.units = res),
      catchError(error => console.assert)
    ).subscribe();

  }

}
