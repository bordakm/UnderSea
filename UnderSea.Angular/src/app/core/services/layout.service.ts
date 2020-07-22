import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { ApiClient, MainPageClient, MainPageViewModel, RoundsDTO } from '../../shared/index';

@Injectable({
  providedIn: 'root',
})
export class LayoutService {

  constructor(private client: ApiClient, private clientm: MainPageClient) { }

  getEverything(): Observable<MainPageViewModel>{
    return this.client.mainPage();
  }

  newRound(): Observable<any>{
    const num: RoundsDTO = new RoundsDTO({
      number: 1
    });
    return this.clientm.newround(num);
  }

}
