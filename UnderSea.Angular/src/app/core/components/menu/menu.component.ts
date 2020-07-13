import { Component, OnInit, Inject } from '@angular/core';
import { Router } from '@angular/router';

import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { ArmyComponent } from 'src/app/features/army/components/army.component';
import { AttackComponent } from 'src/app/features/attack/components/attack.component';
import { BuildingsComponent } from 'src/app/features/buildings/components/buildings.component';
import { FightComponent } from 'src/app/features/fight/components/fight.component';
import { ScoreboardComponent } from 'src/app/features/scoreboard/components/scoreboard.component';
import { UpgradesComponent } from 'src/app/features/upgrades/components/upgrades.component';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {
  animal: string;

  constructor(private router: Router, public dialog: MatDialog) { }

  ngOnInit(): void {
  }

  openArmy(): void{
    this.router.navigate(['army']);
  }

  openAttack(): void{
    this.router.navigate(['attack']);
  }

  openBuildings(): void{
    this.router.navigate(['buildings']);
  }

  openFight(): void{
    this.router.navigate(['fight']);
  }

  openScoreBoard(): void{
    this.router.navigate(['scoreboard']);
  }

  openUpgrades(): void{
    this.router.navigate(['upgrades']);
  }
}


