import { Component, OnInit, Inject } from '@angular/core';

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

  constructor(public dialog: MatDialog) { }

  ngOnInit(): void {
  }

  openArmy(): void{
    const dialogRef = this.dialog.open(ArmyComponent, {
      height: '400px',
      width: '600px',
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }

  openAttack(): void{
    const dialogRef = this.dialog.open(AttackComponent, {
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }

  openBuildings(): void{
    const dialogRef = this.dialog.open(BuildingsComponent, {
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }

  openFight(): void{
    const dialogRef = this.dialog.open(FightComponent, {
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }

  openScoreBoard(): void{
    const dialogRef = this.dialog.open(ScoreboardComponent, {
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }

  openUpgrades(): void{
    const dialogRef = this.dialog.open(UpgradesComponent, {
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }
}


