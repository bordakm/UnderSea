import { Component, OnInit } from '@angular/core';

import { LayoutService } from '../../services/layout.service';
import { tap, catchError } from 'rxjs/operators';
import { UnitViewModel, MainPageViewModel } from '../../../shared/index';
import { LayoutComponent } from '../layout/layout.component';
import { MatSnackBar } from '@angular/material/snack-bar';
import { environment } from 'src/environments/environment';
import { RefreshDataService } from '../../services/refresh-data.service';
import { of, Observable } from 'rxjs';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  everything: MainPageViewModel;

  baseUrl = environment.apiUrl;

  constructor(
    private service: LayoutService,
    public layout: LayoutComponent,
    private snackbar: MatSnackBar,
    private refreshService: RefreshDataService
    ) { }

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

  newRound(): void{
    this.service.newRound(
    ).pipe(
      tap(res => {
        this.snackbar.open('Új kör', 'Bezár', {
          duration: 3000,
          panelClass: ['my-snackbar'],
        });
        this.refreshService.refresh(true);
      }),
      catchError(this.handleError('Nem sikerült az új kör indítása'))
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
