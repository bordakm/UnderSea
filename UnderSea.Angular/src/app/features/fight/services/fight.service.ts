import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { UnitViewModel, ApiClient, AttackDTO, AttacksClient, IOutgoingAttackViewModel, OutgoingAttackViewModel } from '../../../shared/index';
import { IFightUnitsViewModel } from '../models/fight.model';


@Injectable({
  providedIn: 'root',
})
export class FightService {

  constructor(private http: HttpClient, private client: AttacksClient) { }

  getFight(): Observable<OutgoingAttackViewModel[]>{
    return this.client.getoutgoing();
  }

}
