import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { IUserViewModel } from '../models/scoreboard.model';

import { UnitViewModel, ApiClient, IScoreboardViewModel } from '../../../shared/index';

@Injectable({
    providedIn: 'root',
  })
  export class ScoreboardService {

    constructor(private http: HttpClient, private client: ApiClient) { }

    getUser(): Observable<IUserViewModel[]>{
        return this.client.scoreboard(null, null, null).pipe(
            map((dtos: IScoreboardViewModel[]): IUserViewModel[] =>
                dtos.map(dto => ({
                    name: dto.userName,
                    points: dto.place,
                    score: dto.score,
                }))
        )
    );
    }
  }
