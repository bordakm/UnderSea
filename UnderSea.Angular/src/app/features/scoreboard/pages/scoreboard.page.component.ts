import { Component, OnInit } from '@angular/core';
import { IUserViewModel } from '../models/scoreboard.model';

import { ScoreboardService } from '../services/scoreboard.service';
import { tap, catchError } from 'rxjs/operators';
import { ScoreboardViewModel } from 'src/app/shared';
import { MatSliderChange } from '@angular/material/slider';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Observable, of } from 'rxjs';
import { RefreshDataService } from 'src/app/core/services/refresh-data.service';

@Component({
  selector: 'app-scoreboard-page',
  templateUrl: './scoreboard.page.component.html',
  styleUrls: ['./scoreboard.page.component.scss']
})
export class ScoreboardPageComponent implements OnInit {

  user: IUserViewModel = {
    name: 'józsiiwinner12',
    points: 84411,
    score: 1,
  };

  users: ScoreboardViewModel[];

  constructor(private service: ScoreboardService, private snackbar: MatSnackBar, private refreshService: RefreshDataService) { }

  ngOnInit(): void {
    this.getData();
    this.refreshService.data.subscribe(res => {
      this.getData();
    });
  }
  
  getData(): void{
    this.service.getUser().pipe(
      tap(res => this.users = res),
      catchError(error => this.handleError<ScoreboardViewModel[]>('Nem sikerült a ranglétra betöltése', []))
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
