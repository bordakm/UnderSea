import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../shared/shared.module';
import { FightRoutingModule } from './fight-routing.module';
import { FightComponent } from './components/fight.component';

@NgModule({
  declarations: [
    FightComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    FightRoutingModule,
  ],
  exports: [
  ]
})
export class FightModule { }
