import { Component, OnInit, Input} from '@angular/core';
import { IUserViewModel } from '../models/scoreboard.model';
import { ScoreboardViewModel } from 'src/app/shared';

@Component({
  selector: 'app-scoreboard',
  templateUrl: './scoreboard.component.html',
  styleUrls: ['./scoreboard.component.scss']
})
export class ScoreboardComponent implements OnInit {

  @Input() user: ScoreboardViewModel;

  constructor() { }

  ngOnInit(): void {
  }

}
