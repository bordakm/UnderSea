import { Component, OnInit } from '@angular/core';
import { IBuildingsViewModel, ICatsViewModel } from '../models/buildings.model';
import { BuildingsService } from '../services/buildings.service';
import { tap, catchError } from 'rxjs/operators';
import { ICatsDto } from '../models/buildings.dto';

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
  };

  streamManager: IBuildingsViewModel = {
    name: 'Áramlásirányító',
    count: 0,
    price: 35,
  };

  bossCat: ICatsViewModel = {
    type: null,
    text: null,
    status: null,
  };

  buildings: IBuildingsViewModel[];

  constructor(private service: BuildingsService) { }

  ngOnInit(): void {
    this.service.getBuildings().pipe(
      tap(res => this.buildings = res),
      catchError(error => console.assert)
    ).subscribe();

  }

  enableButton(value): void{
    this.isSelected = value;
    this.clicked = true;
  }

}
