import { NgModule } from '@angular/core';
import { SharedModule } from '../../shared/shared.module';
import { ArmyRoutingModule } from './army-routing.module';
import { UnitComponent } from './components/unit.component';
import { ArmyPageComponent } from './pages/army.page.component';
import { CommonModule } from '@angular/common';


@NgModule({
  declarations: [
    UnitComponent,
    ArmyPageComponent,
  ],
  imports: [
    CommonModule,
    SharedModule,
    ArmyRoutingModule,
  ],
  exports: [
  ]
})
export class ArmyModule { }
