import { Component, OnInit } from '@angular/core';
import { IUpgradesViewModel } from '../models/upgrades.model';

import {UpgradesService } from '../services/upgrades.service'
import { tap, catchError } from 'rxjs/operators';
import { UpgradeViewModel } from 'src/app/shared';
import { environment } from 'src/environments/environment';
import { MatSnackBar } from '@angular/material/snack-bar';
import { of } from 'rxjs';

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

  upgrades: UpgradeViewModel[];

  constructor(private service: UpgradesService, private snackbar: MatSnackBar) { }

  ngOnInit(): void {
    this.service.getUpgrades().pipe(
      tap(res => this.upgrades = res),
      catchError(error => console.assert)
    ).subscribe();
  }

  enableButton(value: string, id: number): void{
    this.isSelected = value;
    this.researchId = id;
    this.clicked = true;
  }

  buyUpgrade(): void{
    this.service.research(this.researchId
      ).pipe(
        tap(res => {
          this.snackbar.open('Sikeres fejlesztés!', 'Bezár', {
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
