import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { StudentsDataComponent } from './students-data.component';

@NgModule({
    declarations: [StudentsDataComponent],
    imports: [
       CommonModule,
       RouterModule.forChild([{path: '', component: StudentsDataComponent}])
    ]
 })
 export class StudentsDataModule {
 }