import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';


import { ApiClient, UnitViewModel, MainPageClient, MainPageViewModel } from '../../shared/index';

@Injectable({
  providedIn: 'root',
})
export class LayoutService {

  constructor(private http: HttpClient, private client: ApiClient) { }

  getEverything(): Observable<MainPageViewModel>{
    return this.client.mainPage();
  }

}
