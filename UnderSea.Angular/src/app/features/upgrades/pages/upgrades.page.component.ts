import { Component, OnInit } from '@angular/core';
import { IUpgradesViewModel } from '../models/upgrades.model';

import { UpgradesService } from '../services/upgrades.service'
import { tap, catchError } from 'rxjs/operators';
import { UpgradeViewModel } from 'src/app/shared';
import { environment } from 'src/environments/environment';
import { MatSnackBar } from '@angular/material/snack-bar';
import { of, Observable } from 'rxjs';
import { RefreshDataService } from 'src/app/core/services/refresh-data.service';

@Component({
  selector: 'app-upgrades-page',
  templateUrl: './upgrades.page.component.html',
  styleUrls: ['./upgrades.page.component.scss']
})
export class UpgradesPageComponent implements OnInit {

  clicked = false;
  isSelected: string;
  baseUrl = environment.apiUrl;
  researchId: number;
  inProgress: boolean;

  upgrades: UpgradeViewModel[];

  constructor(private service: UpgradesService, private snackbar: MatSnackBar, private refreshService: RefreshDataService) { }

  ngOnInit(): void {
    this.getData();
    this.refreshService.data.subscribe(res => {
      this.getData();
    });
  }

  getData(): void {
    this.service.getUpgrades().pipe(
      tap(res => {
        this.upgrades = res;
        this.purchased();
      }),
      catchError(error => this.handleError<UpgradeViewModel[]>('Nem sikerült a fejlesztések betöltése', []))
    ).subscribe();
  }

  enableButton(value: string, id: number): void {
    this.upgrades.forEach(element => {
      if (element.id === id && element.isPurchased) {
        return;
      } else if (this.inProgress) {
        return;
      } else {
        this.isSelected = value;
        this.researchId = id;
        this.clicked = true;
      }
    });

  }

  buyUpgrade(): void {
    this.service.research(this.researchId
    ).pipe(
      tap(res => {
        this.snackbar.open('Sikeres fejlesztés!', 'Bezár', {
          duration: 3000,
          panelClass: ['my-snackbar'],
        });
        this.refreshService.refresh(true);
      }),
      catchError(err => this.handleError('Nem sikerült a fejlesztés'))
    ).subscribe();
    this.isSelected = '';
    this.researchId = 0;
    this.clicked = false;
  }

  purchased(): void {
    this.inProgress = false;
    this.upgrades?.forEach(element => {
      if (element.remainingRounds > 0) {
        this.inProgress = true;
        this.isSelected = '';
        this.researchId = -1;
        this.clicked = false;
      }
    });
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
