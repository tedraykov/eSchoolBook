import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { TeachersDataComponent } from './teachers-data.component';

@NgModule({
    declarations: [],
    imports: [
       CommonModule,
       RouterModule.forChild([{path: '', component: TeachersDataComponent}])
    ]
 })
 export class TeachersDataModule {
 }