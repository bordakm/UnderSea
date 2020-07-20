import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';


import { ApiClient, IUnitViewModel, UnitViewModel } from '../../shared/index';

@Injectable({
  providedIn: 'root',
})
export class LayoutService {

  constructor(private http: HttpClient, private client: ApiClient) { }

  getUnits(): Observable<IUnitViewModel[]>{
    return this.client.unitsGet().pipe(
        map((dtos: UnitViewModel[]): IUnitViewModel[] =>
                 dtos.map(dto => ({
                    name: dto.name,
                    count: dto.count,
                    imageUrl: dto.imageUrl
                }))
        )
    );
  }

}
