import { NgModule } from '@angular/core';
import { SharedModule } from '../../shared/shared.module';
import { ArmyRoutingModule } from './army-routing.module';
import { ArmyComponent } from './components/army.component';
import { ArmyPageComponent } from './pages/army.page.component';

@NgModule({
  declarations: [
    ArmyComponent,
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
