import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../shared/shared.module';
import { UpgradesRoutingModule } from './upgrades-routing.module';
import { UpgradesComponent } from './components/upgrades.component';

@NgModule({
  declarations: [
    UpgradesComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    UpgradesRoutingModule,
  ],
  exports: [
  ]
})
export class UpgradesModule { }
