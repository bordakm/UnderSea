import { Component, OnInit } from '@angular/core';
import { IArmyViewModel } from '../models/army.model';

import { ArmyService } from '../services/army.service';
import { tap, catchError, concatMap } from 'rxjs/operators';
import { SimpleUnitViewModel, UnitPurchaseDTO } from 'src/app/shared';
import { MatSnackBar } from '@angular/material/snack-bar';
import { of } from 'rxjs';

@Component({
  selector: 'app-army-page',
  templateUrl: './army.page.component.html',
  styleUrls: ['./army.page.component.scss']
})
export class ArmyPageComponent implements OnInit {

  unitsModel: IArmyViewModel[];

  purchaseModel: SimpleUnitViewModel[];
  data: UnitPurchaseDTO[] = [];

  constructor(private service: ArmyService, private snackbar: MatSnackBar) { }

  ngOnInit(): void {
    this.service.getUnits().pipe(
      tap(res => this.unitsModel = res),
      catchError(error => console.assert)
    ).subscribe();
  }

  increase(id: number): void{
    this.unitsModel.forEach(element => {
      if (element.id === id){
        element.purchaseCount += 1;
      }
    });
  }

  decrease(id: number): void{
    this.unitsModel.forEach(element => {
      if (element.id === id && element.purchaseCount > 0){
        element.purchaseCount -= 1;
      }
    });
  }

  buyUnits(): void{
    this.unitsModel.forEach(element => {
      const temp: UnitPurchaseDTO = new UnitPurchaseDTO({
        typeId: element.id,
        count: element.purchaseCount
      });
      this.data.push(temp);
    });
    this.service.buyUnits(this.data
      ).pipe(
        tap(res => {
          this.snackbar.open('Sikeres támadás!', 'Bezár', {
            duration: 3000,
            panelClass: ['my-snackbar'],
          });
        }),
        catchError(err => {
          return of(this.snackbar.open('A művelet sikertelen', 'Bezár', {
            duration: 3000,
            panelClass: ['my-snackbar'],
          }));
        })
      ).subscribe();
    window.location.reload();
  }
}
