import { Component, Input, Output, ViewChild } from '@angular/core';
import { IAttackUnitViewModel } from '../models/attack.model';
import { MatSlider } from '@angular/material/slider';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-attack',
  templateUrl: './attack.component.html',
  styleUrls: ['./attack.component.scss']
})
export class AttackComponent {

  @Input() unit: IAttackUnitViewModel;
  @Input() reset: boolean;

  @Output() @ViewChild(MatSlider) matslider: MatSlider;

  baseUrl = environment.apiUrl;

  constructor() { }

  addValue(): void{
    this.unit.sentCount = this.matslider.value;
  }

}
