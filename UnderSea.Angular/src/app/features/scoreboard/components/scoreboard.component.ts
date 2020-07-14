import { Component, OnInit, Input} from '@angular/core';
import { IUserViewModel } from '../models/scoreboard.model';

@Component({
  selector: 'app-scoreboard',
  templateUrl: './scoreboard.component.html',
  styleUrls: ['./scoreboard.component.scss']
})
export class ScoreboardComponent implements OnInit {

  @Input() user: IUserViewModel;
  
  constructor() { }

  ngOnInit(): void {
  }

}
