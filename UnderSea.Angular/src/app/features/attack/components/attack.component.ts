import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { IAttackUnitViewModel } from '../models/attack.model';
import { AvailableUnitViewModel, SendUnitDTO } from 'src/app/shared';

@Component({
  selector: 'app-attack',
  templateUrl: './attack.component.html',
  styleUrls: ['./attack.component.scss']
})
export class AttackComponent implements OnInit {

  @Input() unit: AvailableUnitViewModel;

  @Output() unitValue = new EventEmitter<SendUnitDTO>();
  value: SendUnitDTO;

  constructor() { }

  ngOnInit(): void {
  }

  getSliderValue(unitId: number, count: number): void{
    this.value = new SendUnitDTO({
      id: unitId,
      sendCount: count
    });
    return this.unitValue.emit(this.value);
  }

}
