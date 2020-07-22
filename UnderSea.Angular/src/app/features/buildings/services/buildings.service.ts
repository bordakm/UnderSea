import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IBuildingsViewModel, ICatsViewModel } from '../models/buildings.model';
import { IBuildingsDto, ICatsDto } from '../models/buildings.dto';

import { BuildingsClient, ApiClient, IBuildingInfoViewModel, IdDTO } from '../../../shared/index';

@Injectable({
  providedIn: 'root',
})
export class BuildingsService {

  constructor(private http: HttpClient, private client: ApiClient, private clientb: BuildingsClient) { }

  getBuildings(): Observable<IBuildingInfoViewModel[]>{
    return this.client.buildings();
  }

  buyBuilding(id: number): Observable<any>{
    const iddto: IdDTO = new IdDTO(
      { id }
    );
    return this.clientb.purchase(iddto);
  }


}
