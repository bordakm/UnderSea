import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { IAttackUnitViewModel } from '../../attack/models/attack.model';
import {IOutgoingAttackViewModel, AttacksClient, AvailableUnitViewModel, ScoreboardViewModel, AttackDTO } from '../../../shared/index';

@Injectable({
  providedIn: 'root',
})
export class AttackService {

  constructor(private http: HttpClient, private client: AttacksClient) { }

  getAttacks(): Observable<IAttackUnitViewModel[]>{
    return this.client.getunits().pipe(
      map((dtos: AvailableUnitViewModel[]): IAttackUnitViewModel[] =>
               dtos.map(dto => ({
                  id: dto.id,
                  name: dto.name,
                  availableCount: dto.availableCount,
                  imageUrl: dto.imageUrl,
                  sentCount: 0
              }))
      )
    );
  }

  getCountries(term: string): Observable<ScoreboardViewModel[]>{
    return this.client.searchtargets(term, 1, 10);
  }

  sendUnits(attack: AttackDTO): Observable<any>{
    return this.client.send(attack);
  }

}
