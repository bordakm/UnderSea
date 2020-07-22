import { Component, OnInit, Output, Input } from '@angular/core';
import { IAttackUnitViewModel } from '../../attack/models/attack.model';
import { IOutgoingAttackViewModel, ScoreboardViewModel, AttackDTO, SendUnitDTO, IdDTO } from 'src/app/shared';

import { AttackService } from '../services/attack.service';
import { tap, catchError } from 'rxjs/operators';
import { MatSlider } from '@angular/material/slider';
import { MatSnackBar } from '@angular/material/snack-bar';
import { of } from 'rxjs';

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

  formatLabel(value: number): number{
    this.units = value;
    return value;
  }

  constructor(private service: AttackService, private snackbar: MatSnackBar) { }

  ngOnInit(): void {
    this.service.getAttacks().pipe(
      tap(res => this.availableUnits = res),
      catchError(error => console.assert)
    ).subscribe();

    this.service.getCountries().pipe(
      tap(res => this.countries = res),
      catchError(error => console.assert)
    ).subscribe();
  }

  choose(id: number): void{
    this.attackData.defenderUserId = id;
    this.clicked = true;
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
        }),
        catchError(err => {
          return of(this.snackbar.open('A művelet sikertelen', 'Bezár', {
            duration: 3000,
            panelClass: ['my-snackbar'],
          }));
        })
      ).subscribe();
    this.clicked = false;
  }
}
