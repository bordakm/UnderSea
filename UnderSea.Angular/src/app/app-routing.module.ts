import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LayoutComponent } from './core/components/layout/layout.component';
import { LoginComponent } from './core/pages/login/login.component';

import { AuthGuardService } from '../app/core/services/auth-guard.service';

const routes: Routes = [
  {
    path: '',
    component: LayoutComponent,
    loadChildren: () => import('./core/core.module').then(m => m.CoreModule),
    canActivate: [AuthGuardService]
  },
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'army',
    component: LayoutComponent,
    loadChildren: () => import('./features/army/army.module').then(m => m.ArmyModule),
    canActivate: [AuthGuardService]
  },
  {
    path: 'attack',
    component: LayoutComponent,
    loadChildren: () => import('./features/attack/attack.module').then(m => m.AttackModule),
    canActivate: [AuthGuardService]
  },
  {
    path: 'buildings',
    component: LayoutComponent,
    loadChildren: () => import('./features/buildings/buildings.module').then(m => m.BuildingsModule),
    canActivate: [AuthGuardService]
  },
  {
    path: 'fight',
    component: LayoutComponent,
    loadChildren: () => import('./features/fight/fight.module').then(m => m.FightModule),
    canActivate: [AuthGuardService]
  },
  {
    path: 'scoreboard',
    component: LayoutComponent,
    loadChildren: () => import('./features/scoreboard/scoreboard.module').then(m => m.ScoreboardModule),
    canActivate: [AuthGuardService]
  },
  {
    path: 'upgrades',
    component: LayoutComponent,
    loadChildren: () => import('./features/upgrades/upgrades.module').then(m => m.UpgradesModule),
    canActivate: [AuthGuardService]
  },
  { path: '**', redirectTo: '' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
