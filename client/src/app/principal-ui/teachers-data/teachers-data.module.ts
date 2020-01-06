import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { TeachersDataComponent } from './teachers-data.component';

@NgModule({
    declarations: [TeachersDataComponent],
    imports: [
       CommonModule,
       RouterModule.forChild([{path: '', component: TeachersDataComponent}])
    ]
 })
 export class TeachersDataModule {
 }