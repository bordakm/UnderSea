import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { IUserViewModel } from '../models/scoreboard.model';

import { UnitViewModel, ApiClient, IScoreboardViewModel, ScoreboardViewModel } from '../../../shared/index';

@Injectable({
    providedIn: 'root',
  })
  export class ScoreboardService {

    constructor(private http: HttpClient, private client: ApiClient) { }

    getUser(): Observable<ScoreboardViewModel[]>{
        return this.client.scoreboard('', 1, 10);
    }
  }
