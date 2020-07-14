import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { FightPageComponent } from './pages/fight.page.component';

const routes: Routes = [
  { path: '', component: FightPageComponent },
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FightRoutingModule { }
