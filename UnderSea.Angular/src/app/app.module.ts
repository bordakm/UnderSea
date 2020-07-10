import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CoreModule } from './core/core.module';
import { ArmyComponent } from './features/army/components/army.component';
import { AttackComponent } from './features/attack/components/attack.component';
import { BuildingsComponent } from './features/buildings/components/buildings.component';
import { FightComponent } from './features/fight/components/fight.component';
import { ScoreboardComponent } from './features/scoreboard/components/scoreboard.component';
import { UpgradesComponent } from './features/upgrades/components/upgrades.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatDialogModule, MAT_DIALOG_DEFAULT_OPTIONS } from '@angular/material/dialog';

@NgModule({
  declarations: [
    AppComponent,
    ArmyComponent,
    AttackComponent,
    BuildingsComponent,
    FightComponent,
    ScoreboardComponent,
    UpgradesComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CoreModule,
    BrowserAnimationsModule,
    CoreModule,
    MatDialogModule
  ],
  entryComponents: [
    ArmyComponent
  ],
  providers: [
    {provide: MAT_DIALOG_DEFAULT_OPTIONS, useValue: {hasBackdrop: false}}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
