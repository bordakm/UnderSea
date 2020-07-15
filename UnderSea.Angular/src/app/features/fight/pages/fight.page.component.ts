import { Component, OnInit } from '@angular/core';
import { IFightUnitsViewModel } from '../models/fight.model';

@Component({
  selector: 'app-fight-page',
  templateUrl: './fight.page.component.html',
  styleUrls: ['./fight.page.component.scss']
})
export class FightPageComponent implements OnInit {

  unitsModel: IFightUnitsViewModel = {
    cityName: 'Atlantisz',
    sharkCount: 6,
    sealCount: 30,
    seahorseCount: 45
  };
  constructor() { }

  ngOnInit(): void {
  }

  

}
