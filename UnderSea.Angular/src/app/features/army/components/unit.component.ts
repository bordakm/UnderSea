import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { IArmyViewModel } from '../models/army.model';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-unit',
  templateUrl: './unit.component.html',
  styleUrls: ['./unit.component.scss']
})
export class UnitComponent implements OnInit {

  @Input() unit: IArmyViewModel;

  @Output() clickAdd = new EventEmitter();
  @Output() clickDecrease = new EventEmitter();

  ngOnInit(): void {
  }

}
