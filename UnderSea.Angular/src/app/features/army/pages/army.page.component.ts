import { Component, OnInit } from '@angular/core';
import { IUnitViewModel } from '../models/army.model';

import { ArmyService } from '../services/army.service';
import { tap, catchError } from 'rxjs/operators';
import { IUserViewModel } from '../../scoreboard/models/scoreboard.model';

@Component({
  selector: 'app-army-page',
  templateUrl: './army.page.component.html',
  styleUrls: ['./army.page.component.scss']
})
export class ArmyPageComponent implements OnInit {

  laserSharkModel: IUnitViewModel = {
    name: 'Lézercápa',
    price: null,
    attackScore: null,
    defenseScore: null,
    pearlCostPerTurn: null,
    coralCostPerTurn: null,
    buyNumber: 0
  };

  stormSealModel: IUnitViewModel = {
    name: 'Rohamfóka',
    price: null,
    attackScore: null,
    defenseScore: null,
    pearlCostPerTurn: null,
    coralCostPerTurn: null,
    buyNumber: 0
  };

  combatSeaHorseModel: IUnitViewModel = {
    name: 'Csatacsikó',
    price: null,
    attackScore: null,
    defenseScore: null,
    pearlCostPerTurn: null,
    coralCostPerTurn: null,
    buyNumber: 0
  };

  unitsModel: IUnitViewModel[];

  constructor(private service: ArmyService) { }

  ngOnInit(): void {
    this.service.getUnits().pipe(
      tap(res => this.unitsModel = res),
      catchError(error => console.assert)
    ).subscribe();
  }



  deleteOneLasersharkFromCart(): void{
    if ( this.laserSharkModel.buyNumber > 0 ){
      this.laserSharkModel.buyNumber -= 1;
    }
  }

  addOneLasersharkToCart(): void{
      this.laserSharkModel.buyNumber += 1;
  }


  deleteOneStormsealFromCart(): void{
    if ( this.stormSealModel.buyNumber > 0 ){
      this.stormSealModel.buyNumber -= 1;
    }
  }

  addOneStormsealToCart(): void{
    this.stormSealModel.buyNumber += 1;
  }

  deleteOneCombatSeahorseFromCart(): void{
    if ( this.combatSeaHorseModel.buyNumber > 0 ){
      this.combatSeaHorseModel.buyNumber -= 1;
    }
  }

  addOneCombatSeahorseToCart(): void{
    this.combatSeaHorseModel.buyNumber += 1;
  }
}
