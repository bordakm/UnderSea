import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { IArmyViewModel } from '../models/army.model';

import { UnitViewModel, ApiClient, SimpleUnitViewModel, UnitPurchaseDTO } from '../../../shared/index';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root',
})
export class ArmyService {

  constructor(private http: HttpClient, private client: ApiClient) { }

  getUnits(): Observable<IArmyViewModel[]>{
    console.log(environment.apiUrl);
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
                    imageUrl: environment.apiUrl + dto.imageUrl,
                    purchaseCount: 0
                }))
        )
    );
  }

  buyUnits(unitsPurchased: UnitPurchaseDTO[]): Observable<SimpleUnitViewModel[]>{
    return this.client.unitsPost(unitsPurchased);
   }


}
