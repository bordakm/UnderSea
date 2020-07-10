import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';

import { SharedModule } from '../shared/shared.module';

import { ArmyComponent } from './army/components/army.component';
import { AttackComponent } from './attack/components/attack.component';
import { BuildingsComponent } from './buildings/components/buildings.component';
import { FightComponent } from './fight/components/fight.component';
import { ScoreboardComponent } from './scoreboard/components/scoreboard.component';
import { UpgradesComponent } from './upgrades/components/upgrades.component';




@NgModule({
  declarations: [
    ArmyComponent,
    AttackComponent,
    BuildingsComponent,
    FightComponent,
    ScoreboardComponent,
    UpgradesComponent,
  ],
  imports: [
    CommonModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  exports: [
    SharedModule
  ],
})
export class FeaturesModule { }