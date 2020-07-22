import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { UnitViewModel, ApiClient, UpgradeViewModel, UpgradesClient, IdDTO } from '../../../shared/index';


@Injectable({
  providedIn: 'root',
})
export class UpgradesService {

  constructor(private http: HttpClient, private client: ApiClient, private clientu: UpgradesClient) { }

  getUpgrades(): Observable<UpgradeViewModel[]>{
    return this.client.upgrades();
  }

  research(id: number): Observable<any>{
      const iddto: IdDTO = new IdDTO(
        { id }
      );
      return this.clientu.research(iddto);
  }
}
