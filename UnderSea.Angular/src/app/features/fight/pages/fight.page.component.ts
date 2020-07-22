import { Component, OnInit } from '@angular/core';
import { IFightUnitsViewModel } from '../models/fight.model';

import { FightService } from '../services/fight.service';
import { tap, catchError } from 'rxjs/operators';
import { OutgoingAttackViewModel } from 'src/app/shared';

@Component({
  selector: 'app-fight-page',
  templateUrl: './fight.page.component.html',
  styleUrls: ['./fight.page.component.scss']
})
export class FightPageComponent implements OnInit {

  fightModels: OutgoingAttackViewModel[];
  empty: boolean;

  constructor(private service: FightService) { }

  ngOnInit(): void {
    this.service.getFight().pipe(
      tap(res => this.fightModels = res),
      catchError(error => console.assert)
    ).subscribe();

    if (Array.isArray(this.fightModels) && this.fightModels.length){
      this.empty = false;
    }else{
      this.empty = true;
    }
  }


}
