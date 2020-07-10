import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';

import { SharedModule } from '../shared/shared.module';
import { CoreRoutingModule } from './core-routing.module';
import { AuthService } from './services/auth.service';
import { LoginComponent } from './components/login/login.component';

import { HeaderComponent } from './components/header/header.component';
import { MainPageComponent } from './components/main-page/main-page.component';
import { MenuComponent } from './components/menu/menu.component';
import { ProfileComponent } from './components/profile/profile.component';
import { LayoutComponent } from './components/layout/layout.component';
import { MAT_DIALOG_DEFAULT_OPTIONS, MatDialogModule } from '@angular/material/dialog';




@NgModule({
  declarations: [
    LoginComponent,
    LayoutComponent,
    HeaderComponent,
    MainPageComponent,
    MenuComponent,
    ProfileComponent,
  ],
  imports: [
    CommonModule,
    SharedModule,
    CoreRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MatDialogModule
  ],
  exports: [
    SharedModule
  ],
})
export class CoreModule { }
