import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../shared/shared.module';
import { BuildingsRoutingModule } from './buildings-routing.module';
import { BuildingsComponent } from './components/buildings.component';

@NgModule({
  declarations: [
    BuildingsComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    BuildingsRoutingModule,
  ],
  exports: [
  ]
})
export class BuildingsModule { }
