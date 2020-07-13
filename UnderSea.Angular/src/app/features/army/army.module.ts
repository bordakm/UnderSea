import { NgModule } from '@angular/core';
import { SharedModule } from '../../shared/shared.module';
import { ArmyRoutingModule } from './army-routing.module';
import { UnitComponent } from './components/unit.component';
import { ArmyPageComponent } from './pages/army.page.component';


@NgModule({
  declarations: [
    UnitComponent,
    ArmyPageComponent,
  ],
  imports: [
    SharedModule,
    ArmyRoutingModule,
  ],
  exports: [
  ]
})
export class ArmyModule { }
