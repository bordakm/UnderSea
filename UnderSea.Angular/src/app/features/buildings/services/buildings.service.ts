import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IBuildingsViewModel, ICatsViewModel } from '../models/buildings.model';
import { IBuildingsDto, ICatsDto } from '../models/buildings.dto';

import { BuildingsClient, ApiClient, IBuildingInfoViewModel } from '../../../shared/index';

@Injectable({
  providedIn: 'root',
})
export class BuildingsService {

  constructor(private http: HttpClient, private client: ApiClient) { }

  getBuildings(): Observable<IBuildingsViewModel[]>{
    return this.client.buildings().pipe(
        map((dtos: IBuildingInfoViewModel[]): IBuildingsViewModel[] =>
                 dtos.map(dto => ({
                    name: dto.name,
                    count: dto.count,
                    price: dto.price,
                    description: dto.description,
                }))
        )
    );
  }


}
