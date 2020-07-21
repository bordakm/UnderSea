import { Component, OnInit } from '@angular/core';
import { IArmyViewModel } from '../models/army.model';

import { ArmyService } from '../services/army.service';
import { tap, catchError } from 'rxjs/operators';
import { UnitPurchaseDTO, UnitViewModel, SimpleUnitViewModel } from 'src/app/shared';

@Component({
  selector: 'app-army-page',
  templateUrl: './army.page.component.html',
  styleUrls: ['./army.page.component.scss']
})
export class ArmyPageComponent implements OnInit {

  unitsModel: IArmyViewModel[];

  purchaseModel: SimpleUnitViewModel[];

  constructor(private service: ArmyService) { }

  ngOnInit(): void {
    this.service.getUnits().pipe(
      tap(res => this.unitsModel = res),
      catchError(error => console.assert)
    ).subscribe();
  }

  increase(id: number): void{
    this.unitsModel.forEach(element => {
      if (element.id === id){
      }
    });
  }

  decrease(id: number): void{
    this.unitsModel.forEach(element => {
      if (element.id === id){
      }
    });
  }
}
