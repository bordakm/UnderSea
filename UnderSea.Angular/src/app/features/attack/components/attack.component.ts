import { Component, OnInit, Input, Output, EventEmitter, ViewChild } from '@angular/core';
import { IAttackUnitViewModel } from '../models/attack.model';
import { AvailableUnitViewModel, SendUnitDTO } from 'src/app/shared';
import { MatSlider } from '@angular/material/slider';

@Component({
  selector: 'app-attack',
  templateUrl: './attack.component.html',
  styleUrls: ['./attack.component.scss']
})
export class AttackComponent implements OnInit {

  @Input() unit: AvailableUnitViewModel;
  @Input() reset: boolean;
  @Output() unitValue = new EventEmitter<SendUnitDTO>();

  @Output() slider: MatSlider;
  @ViewChild(MatSlider) matslider: MatSlider;

  constructor() { }

  ngOnInit(): void {
    this.slider = this.matslider;
  }

  getSliderValue(unitId: number, count: number): void{
    const value: SendUnitDTO = new SendUnitDTO({
      id: unitId,
      sendCount: count
    });
    return this.unitValue.emit(value);
  }

}
