import { Component, OnInit } from '@angular/core';

import { LayoutService } from '../../services/layout.service';
import { IUnitViewModel, MainPageViewModel } from 'src/app/shared';
import { tap, catchError } from 'rxjs/operators';
import { MatSnackBar } from '@angular/material/snack-bar';
import { RefreshDataService } from '../../services/refresh-data.service';
import { of, Observable } from 'rxjs';


@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss']
})
export class LayoutComponent implements OnInit {

  everything: MainPageViewModel;

  constructor(
    private service: LayoutService,
    private snackbar: MatSnackBar,
    private refreshService: RefreshDataService) { }

  ngOnInit(): void {
    this.getData();
    this.refreshService.data.subscribe(res => {
      this.getData();
    });
  }

  getData(): void{
    this.service.getEverything().pipe(
      tap(res => this.everything = res),
      catchError(this.handleError<MainPageViewModel>('Nem sikerült az adatok betöltése'))
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
