import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { IArmyViewModel } from '../models/army.model';

import { UnitViewModel, ApiClient } from '../../../shared/index';


@Injectable({
  providedIn: 'root',
})
export class ArmyService {

  constructor(private http: HttpClient, private client: ApiClient) { }

  // getUnits(): Observable<UnitViewModel[]>{
  //   return this.client.unitsGet();
  // }

  getUnits(): Observable<IArmyViewModel[]>{
    return this.client.unitsGet().pipe(
        map((dtos: UnitViewModel[]): IArmyViewModel[] =>
                 dtos.map(dto => ({
                    id: dto.id,
                    name: dto.name,
                    count: dto.count,
                    price: dto.price,
                    attackScore: dto.attackScore,
                    defenseScore: dto.defenseScore,
                    pearlCostPerTurn: dto.pearlCostPerTurn,
                    coralCostPerTurn: dto.coralCostPerTurn,
                    imageUrl: dto.imageUrl,
                    purchaseCount: 0
                }))
        )
    );
  }


}
