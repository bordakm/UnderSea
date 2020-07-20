import { Component, OnInit, Output, Input } from '@angular/core';
import { IAttackUnitViewModel, ICountryViewModel } from '../../attack/models/attack.model';
import { IOutgoingAttackViewModel, AvailableUnitViewModel, ScoreboardViewModel, AttackDTO, SendUnitDTO } from 'src/app/shared';

import { AttackService } from '../services/attack.service';
import { tap, catchError } from 'rxjs/operators';

@Component({
  selector: 'app-attack-page',
  templateUrl: './attack.page.component.html',
  styleUrls: ['./attack.page.component.scss']
})
export class AttackPageComponent implements OnInit {

  @Input() unitValue: number;
  @Output() units: number;
  // @Output() id: number;

  availableUnits: AvailableUnitViewModel[];
  countries: ScoreboardViewModel[];
  attackData: AttackDTO;
  clicked: boolean;

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

  choose(id: number): void{
    this.attackData.defenderUserId = id;
    // this.id = id;
    this.clicked = true;
  }

  getUnitCount(unit: SendUnitDTO): void{
    this.attackData.attackingUnits.forEach(element => {
      if (element.id === unit.id){
        element.sendCount = unit.sendCount;
      }
    });
  }

  sendAttack(): void{
    this.service.sendUnits(this.attackData);
  }

}
