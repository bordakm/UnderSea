import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LayoutComponent } from './core/components/layout/layout.component';

const routes: Routes = [
  {
    path: '',
    component: LayoutComponent,
    loadChildren: () => import('./core/core.module').then(m => m.CoreModule)
  },
  {
    path: 'army',
    component: LayoutComponent,
    loadChildren: () => import('./features/army/army.module').then(m => m.ArmyModule)
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
