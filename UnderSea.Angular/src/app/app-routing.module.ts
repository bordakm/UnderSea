import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LayoutComponent } from './core/components/layout/layout.component';
import { LoginComponent } from './core/pages/login/login.component';

import { AuthGuardService } from '../app/core/services/auth-guard.service';

const routes: Routes = [
  {
    path: '',
    component: LayoutComponent,
    children: [
      { path: '', loadChildren: () => import('./core/core.module').then(m => m.CoreModule), },
      { path: 'army', loadChildren: () => import('./features/army/army.module').then(m => m.ArmyModule), },
      { path: 'attack', loadChildren: () => import('./features/attack/attack.module').then(m => m.AttackModule), },
      { path: 'attack', loadChildren: () => import('./features/attack/attack.module').then(m => m.AttackModule), },
      { path: 'buildings', loadChildren: () => import('./features/buildings/buildings.module').then(m => m.BuildingsModule), },
      { path: 'fight', loadChildren: () => import('./features/fight/fight.module').then(m => m.FightModule), },
      { path: 'scoreboard', loadChildren: () => import('./features/scoreboard/scoreboard.module').then(m => m.ScoreboardModule), },
      { path: 'upgrades', loadChildren: () => import('./features/upgrades/upgrades.module').then(m => m.UpgradesModule), },

    ],
    canActivate: [AuthGuardService]
  },
  {
    path: 'login',
    component: LoginComponent,
  },
  { path: '**', redirectTo: '' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
