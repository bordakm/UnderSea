import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { UnitViewModel, ApiClient, UpgradeViewModel } from '../../../shared/index';


@Injectable({
  providedIn: 'root',
})
export class UpgradesService {

  constructor(private http: HttpClient, private client: ApiClient) { }

  getUpgrades(): Observable<UpgradeViewModel[]>{
    return this.client.upgrades();
  }


}
