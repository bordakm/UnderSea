import { Component, OnInit } from '@angular/core';
import { IFightUnitsViewModel } from '../models/fight.model';

import { FightService } from '../services/fight.service';
import { tap, catchError } from 'rxjs/operators';
import { OutgoingAttackViewModel } from 'src/app/shared';
import { Observable, of } from 'rxjs';
import { SimpleSnackBar, MatSnackBar } from '@angular/material/snack-bar';
import { RefreshDataService } from 'src/app/core/services/refresh-data.service';

@Component({
  selector: 'app-fight-page',
  templateUrl: './fight.page.component.html',
  styleUrls: ['./fight.page.component.scss']
})
export class FightPageComponent implements OnInit {

  fightModels: OutgoingAttackViewModel[];
  empty: boolean;

  constructor(private service: FightService, private snackbar: MatSnackBar, private refreshService: RefreshDataService) { }

  ngOnInit(): void {
    this.getData();
    this.refreshService.data.subscribe(res => {
      this.getData();
    });
  }

  getData(): void{
    this.service.getFight().pipe(
      tap(res => this.fightModels = res),
      catchError(error => this.handleError<OutgoingAttackViewModel[]>('Nem sikerült a harcok betöltése', []))
    ).subscribe();
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
