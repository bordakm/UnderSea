import { Component, OnInit } from '@angular/core';
import { IUserViewModel } from '../models/scoreboard.model';

import { ScoreboardService } from '../services/scoreboard.service';
import { tap, catchError } from 'rxjs/operators';
import { ScoreboardViewModel } from 'src/app/shared';

@Component({
  selector: 'app-scoreboard-page',
  templateUrl: './scoreboard.page.component.html',
  styleUrls: ['./scoreboard.page.component.scss']
})
export class ScoreboardPageComponent implements OnInit {

  user: IUserViewModel = {
    name: 'józsiiwinner12',
    points: 84411,
    score: 1,
  };

  users: ScoreboardViewModel[];

  constructor(private service: ScoreboardService) { }

  ngOnInit(): void {
    this.service.getUser().pipe(
      tap(res => this.users = res),
      catchError(error => console.assert)
    ).subscribe();
  }

}
