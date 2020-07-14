import { Component, OnInit } from '@angular/core';
import { IUserViewModel } from '../models/scoreboard.model';

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

  constructor() { }

  ngOnInit(): void {
  }

}
