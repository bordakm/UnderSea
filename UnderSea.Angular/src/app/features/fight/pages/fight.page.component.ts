import { Component, OnInit } from '@angular/core';
import { IFightUnitsViewModel } from '../models/fight.model';

import { FightService } from '../services/fight.service';
import { tap, catchError } from 'rxjs/operators';
import { OutgoingAttackViewModel } from 'src/app/shared';
import { Observable, of } from 'rxjs';
import { SimpleSnackBar, MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-fight-page',
  templateUrl: './fight.page.component.html',
  styleUrls: ['./fight.page.component.scss']
})
export class FightPageComponent implements OnInit {

  fightModels: OutgoingAttackViewModel[];
  empty: boolean;

  constructor(private service: FightService, private snackbar: MatSnackBar) { }

  ngOnInit(): void {
    this.service.getFight().pipe(
      tap(res => this.fightModels = res),
      catchError(error => this.handleError<OutgoingAttackViewModel[]>('Nem sikerült a harcok betöltése', []))
    ).subscribe();

    if (Array.isArray(this.fightModels) && this.fightModels.length > 0){
      this.empty = false;
    }else{
      this.empty = true;
    }
  }

  private handleError<T>(message = 'Hiba', result?: T) {
    return (error: any): Observable<T> => {
      this.snackbar.open(message, 'Bezár', {
        duration: 3000,
        panelClass: ['my-snackbar'],
      });
      return of(result as T);
    };
  }
}
