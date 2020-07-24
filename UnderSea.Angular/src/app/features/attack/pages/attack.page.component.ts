import { Component, OnInit, Output, Input } from '@angular/core';
import { IAttackUnitViewModel } from '../../attack/models/attack.model';
import { ScoreboardViewModel, AttackDTO, SendUnitDTO } from 'src/app/shared';

import { AttackService } from '../services/attack.service';
import { tap, catchError, debounceTime, distinctUntilChanged, switchMap } from 'rxjs/operators';
import { MatSnackBar } from '@angular/material/snack-bar';
import { of, Observable, Subject } from 'rxjs';
import { RefreshDataService } from 'src/app/core/services/refresh-data.service';

@Component({
  selector: 'app-attack-page',
  templateUrl: './attack.page.component.html',
  styleUrls: ['./attack.page.component.scss']
})
export class AttackPageComponent implements OnInit {

  @Input() unitValue: number;
  @Output() units: number;

  availableUnits: IAttackUnitViewModel[];
  countries: ScoreboardViewModel[];

  attackData: AttackDTO = new AttackDTO();
  clicked: boolean;

  searchTerm = new Subject<string>();

  formatLabel(value: number): number{
    this.units = value;
    return value;
  }

  constructor(
    private service: AttackService,
    private snackbar: MatSnackBar,
    private refreshService: RefreshDataService
    ) { }

  ngOnInit(): void {
    this.service.getAttacks().pipe(
      tap(res => this.availableUnits = res),
      catchError(this.handleError<IAttackUnitViewModel[]>('Nem sikerült a támadások betöltése', []))
    ).subscribe();

    this.service.getCountries('').pipe(
      tap(res => this.countries = res),
      catchError(this.handleError<ScoreboardViewModel[]>('Nem sikerült az országok betöltése', []))
    ).subscribe();

    this.searchTerm.pipe(
      debounceTime(300),
      distinctUntilChanged(),
      switchMap((term: string) => this.service.getCountries(term)),
      tap(res => this.countries = res)
    ).subscribe();
  }

  choose(id: number): void{
    this.attackData.defenderUserId = id;
    this.clicked = true;
  }

  search(term: string): void{
    this.searchTerm.next(term);
  }

  sendAttack(): void{
    this.attackData.attackingUnits = this.availableUnits.map((model: IAttackUnitViewModel): SendUnitDTO => new SendUnitDTO({
      id : model.id,
      sendCount : model.sentCount
    }));

    this.service.sendUnits(this.attackData
      ).pipe(
        tap(res => {
          this.snackbar.open('Sikeres támadás!', 'Bezár', {
            duration: 3000,
            panelClass: ['my-snackbar'],
          });
          this.refreshService.refresh(true);
        }),
        catchError(this.handleError('Nem sikerült a támadás elindítása'))
      ).subscribe();
    this.clicked = false;
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
