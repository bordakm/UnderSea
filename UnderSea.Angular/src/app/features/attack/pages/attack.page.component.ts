import { Component, OnInit, Output } from '@angular/core';
import { IAttackUnitViewModel } from '../../attack/models/attack.model';

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

  formatLabel(value: number): number{
    this.units = value;
    return value;
  }

  constructor() { }

  ngOnInit(): void {
  }

}
