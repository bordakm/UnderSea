import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../shared/shared.module';
import { ArmyRoutingModule } from './army-routing.module';
import { ArmyComponent } from './components/army.component';

@NgModule({
  declarations: [
    ArmyComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    ArmyComponent,
  ],
  exports: [
  ]
})
export class ArmyModule { }
