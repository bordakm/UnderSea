import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../shared/shared.module';
import { AttackRoutingModule } from './attack-routing.module';
import { AttackComponent } from './components/attack.component';

@NgModule({
  declarations: [
    AttackComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    AttackRoutingModule,
  ],
  exports: [
  ]
})
export class AttackModule { }
