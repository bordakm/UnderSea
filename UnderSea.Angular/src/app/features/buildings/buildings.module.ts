import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../shared/shared.module';
import { BuildingsRoutingModule } from './buildings-routing.module';
import { BuildingsComponent } from './components/buildings.component';
import { BuildingsPageComponent } from './pages/buildings.page.component';

@NgModule({
  declarations: [
    BuildingsPageComponent,
    BuildingsComponent,
  ],
  imports: [
    CommonModule,
    SharedModule,
    BuildingsRoutingModule,
  ],
  exports: [
  ],
  providers: [
    
  ]
})
export class BuildingsModule { }
