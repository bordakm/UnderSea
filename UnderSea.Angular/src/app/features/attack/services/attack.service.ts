import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


import {IOutgoingAttackViewModel, AttacksClient, AvailableUnitViewModel, ScoreboardViewModel, AttackDTO } from '../../../shared/index';

@Injectable({
  providedIn: 'root',
})
export class AttackService {

  constructor(private http: HttpClient, private client: AttacksClient) { }

  getAttacks(): Observable<AvailableUnitViewModel[]>{
    return this.client.getunits();
  }

  getCountries(): Observable<ScoreboardViewModel[]>{
    return this.client.searchtargets('', 1, 10);
  }

  sendUnits(attack: AttackDTO): void{
    this.client.send(attack);
  }

}
