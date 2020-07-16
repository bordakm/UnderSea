import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { IAttackUnitViewModel } from '../models/attack.model';
import { AvailableUnitViewModel } from 'src/app/shared';

@Component({
  selector: 'app-attack',
  templateUrl: './attack.component.html',
  styleUrls: ['./attack.component.scss']
})
export class AttackComponent implements OnInit {

  @Input() unit: AvailableUnitViewModel;
  @Input() image: string;

  constructor() { }

  ngOnInit(): void {
  }

}
