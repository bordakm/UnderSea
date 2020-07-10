import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';

import { LoginComponent } from './components/login/login.component';
import { MainPageComponent } from './components/main-page/main-page.component';


const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'main', component: MainPageComponent}
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
export class CoreRoutingModule { }
