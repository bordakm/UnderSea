import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import {MatCardModule} from '@angular/material/card';
import {MatInputModule} from '@angular/material/input';
import {MatDividerModule} from '@angular/material/divider';
import {MatButtonModule, MatButton} from '@angular/material/button';
import {MatSliderModule} from '@angular/material/slider';
import {MatListModule} from '@angular/material/list';

import {TableSearchComponent} from './components/table-search.component'

@NgModule({
  declarations: [
    TableSearchComponent,
  ],
  imports: [
    CommonModule,
    MatCardModule,
    MatInputModule,
    MatDividerModule,
    MatButtonModule,
    MatSliderModule,
    MatListModule,
  ],
  exports: [
    MatCardModule,
    MatInputModule,
    MatDividerModule,
    MatButtonModule,
    MatSliderModule,
    MatListModule,
    TableSearchComponent,
  ]
})
export class SharedModule { }
