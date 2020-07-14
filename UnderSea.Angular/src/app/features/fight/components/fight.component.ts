import { Component, OnInit, Input } from '@angular/core';
import { IFightUnitsViewModel } from '../models/fight.model';

@Component({
  selector: 'app-fight',
  templateUrl: './fight.component.html',
  styleUrls: ['./fight.component.scss']
})
export class FightComponent implements OnInit {

  @Input() units: IFightUnitsViewModel;
  constructor() { }

  ngOnInit(): void {
  }

}
