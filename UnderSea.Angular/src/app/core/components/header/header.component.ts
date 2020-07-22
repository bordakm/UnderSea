import { Component, OnInit } from '@angular/core';

import { LayoutService } from '../../services/layout.service';
import { tap, catchError } from 'rxjs/operators';
import { UnitViewModel, MainPageViewModel } from '../../../shared/index';
import { LayoutComponent } from '../layout/layout.component';
import { MatSnackBar } from '@angular/material/snack-bar';
import { environment } from 'src/environments/environment';
import { of } from 'rxjs';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  everything: MainPageViewModel;

  baseUrl = environment.apiUrl;

  constructor(private service: LayoutService, public layout: LayoutComponent, private snackbar: MatSnackBar) { }

  ngOnInit(): void {
    this.service.getEverything().pipe(
      tap(res => this.everything = res),
      catchError(error => console.assert)
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
      }),
      catchError(err => {
        return of(this.snackbar.open('A művelet sikertelen', 'Bezár', {
          duration: 3000,
          panelClass: ['my-snackbar'],
        }));
      })
    ).subscribe();
  }
}
