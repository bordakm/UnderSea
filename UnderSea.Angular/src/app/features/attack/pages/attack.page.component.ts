import { Component, OnInit, Output } from '@angular/core';
import { IAttackUnitViewModel, ICountryViewModel } from '../../attack/models/attack.model';
import { IOutgoingAttackViewModel, AvailableUnitViewModel, ScoreboardViewModel } from 'src/app/shared';

import { AttackService } from '../services/attack.service';
import { tap, catchError } from 'rxjs/operators';

@Component({
  selector: 'app-attack-page',
  templateUrl: './attack.page.component.html',
  styleUrls: ['./attack.page.component.scss']
})
export class AttackPageComponent implements OnInit {

  @Output() units: number;

  laserSharkModel: IAttackUnitViewModel = {
    name: 'Lézercápa',
    count: 1
  };

  stormSealModel: IAttackUnitViewModel = {
    name: 'Rohamfóka',
    count: 1
  };

  combatSeaHorseModel: IAttackUnitViewModel = {
    name: 'Csatacsikó',
    count: 1
  };

  availableUnits: AvailableUnitViewModel[];
  countries: ScoreboardViewModel[];

  formatLabel(value: number): number{
    this.units = value;
    return value;
  }

  constructor(private service: AttackService) { }

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

}
