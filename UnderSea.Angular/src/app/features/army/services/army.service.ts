import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { IUnitViewModel } from '../models/army.model'

import { UnitViewModel, ApiClient } from '../../../shared/index';


@Injectable({
  providedIn: 'root',
})
export class ArmyService {

  constructor(private http: HttpClient, private client: ApiClient) { }

  getUnits(): Observable<IUnitViewModel[]>{
    return this.client.unitsGet().pipe(
        map((dtos: UnitViewModel[]): IUnitViewModel[] =>
                 dtos.map(dto => ({
                    name: dto.name,
                    // count: dto.count,
                    price: dto.price,
                    attackScore: dto.attackScore,
                    defenseScore: dto.defenseScore,
                    pearlCostPerTurn: dto.pearlCostPerTurn,
                    coralCostPerTurn: dto.coralCostPerTurn
                }))
        )
    );
  }


}
