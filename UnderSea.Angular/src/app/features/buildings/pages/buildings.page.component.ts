import { Component, OnInit } from '@angular/core';
import { IBuildingsViewModel } from '../models/buildings.model';

@Component({
  selector: 'app-buildings-page',
  templateUrl: './buildings.page.component.html',
  styleUrls: ['./buildings.page.component.scss']
})
export class BuildingsPageComponent implements OnInit {

  clicked = false;
  isSelected: string;

  reefCastle: IBuildingsViewModel = {
    name: 'Zátonyvár',
    count: 1,
    price: 45,
    givenMembers: 50,
    bearedFood: 200
  };

  streamManager: IBuildingsViewModel = {
    name: 'Áramlásirányító',
    count: 0,
    price: 35,
    givenShelter: 200
  };
  constructor() { }

  ngOnInit(): void {
  }

  enableButton(value): void{
    this.isSelected = value;
    this.clicked = true;
  }

}
