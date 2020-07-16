import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


import {IOutgoingAttackViewModel, AttacksClient, AvailableUnitViewModel } from '../../../shared/index';

@Injectable({
  providedIn: 'root',
})
export class AttackService {

  constructor(private http: HttpClient, private client: AttacksClient) { }

  getAttacks(): Observable<AvailableUnitViewModel[]>{
    return this.client.getunits();
  }

}
