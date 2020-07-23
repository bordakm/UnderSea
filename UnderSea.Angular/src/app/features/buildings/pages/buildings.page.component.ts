import { Component, OnInit } from '@angular/core';
import { IBuildingsViewModel, ICatsViewModel } from '../models/buildings.model';
import { BuildingsService } from '../services/buildings.service';
import { tap, catchError } from 'rxjs/operators';
import { ICatsDto } from '../models/buildings.dto';
import { IBuildingInfoViewModel } from 'src/app/shared';
import { MatSnackBar } from '@angular/material/snack-bar';
import { of, Observable } from 'rxjs';
import { RefreshDataService } from 'src/app/core/services/refresh-data.service';

@Component({
  selector: 'app-buildings-page',
  templateUrl: './buildings.page.component.html',
  styleUrls: ['./buildings.page.component.scss']
})
export class BuildingsPageComponent implements OnInit {

  clicked = false;
  isSelected: string;
  purchaseId: number;
  buildings: IBuildingInfoViewModel[];

  constructor(private service: BuildingsService, private snackbar: MatSnackBar, private refreshService: RefreshDataService) { }

  ngOnInit(): void {
    this.getData();
    this.refreshService.data.subscribe(res => {
      this.getData();
    });
  }

  getData(): void{
    this.service.getBuildings().pipe(
      tap(res => this.buildings = res),
      catchError(error => this.handleError<IBuildingInfoViewModel[]>('Nem sikerült az épületek betöltése', []))
    ).subscribe();
  }

  enableButton(value: string, id: number): void{
    this.isSelected = value;
    this.purchaseId = id;
    this.clicked = true;
  }

  buyBuilding(): void{
    this.service.buyBuilding(this.purchaseId
      ).pipe(
        tap(res => {
          this.snackbar.open('Sikeres vétel!', 'Bezár', {
            duration: 3000,
            panelClass: ['my-snackbar'],
          });
          this.refreshService.refresh(true);
        }),
        catchError(err => this.handleError('Nem sikerült a vásárlás'))
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

