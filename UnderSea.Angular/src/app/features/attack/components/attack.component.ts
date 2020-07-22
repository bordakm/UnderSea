import { Component, OnInit, Input, Output, EventEmitter, ViewChild } from '@angular/core';
import { IAttackUnitViewModel } from '../models/attack.model';
import { AvailableUnitViewModel, SendUnitDTO, IdDTO } from 'src/app/shared';
import { MatSlider } from '@angular/material/slider';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-attack',
  templateUrl: './attack.component.html',
  styleUrls: ['./attack.component.scss']
})
export class AttackComponent implements OnInit {

  @Input() unit: IAttackUnitViewModel;
  @Input() reset: boolean;

  @Output() @ViewChild(MatSlider) matslider: MatSlider;

  baseUrl = environment.apiUrl;

  constructor() { }

  ngOnInit(): void {
    
  }

  addValue(): void{
    this.unit.sentCount = this.matslider.value;
  }

}
