import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';

import { UpgradesPageComponent } from './pages/upgrades.page.component';

const routes: Routes = [
  {path: '', component: UpgradesPageComponent }
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes),
    CommonModule
  ],
  exports: [
    RouterModule
  ]
})
export class UpgradesRoutingModule { }
