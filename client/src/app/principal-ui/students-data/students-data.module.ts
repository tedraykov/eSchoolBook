import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {RouterModule} from '@angular/router';
import {StudentsDataComponent} from './students-data.component';
import {NbButtonModule, NbCardModule} from "@nebular/theme";
import {MatTableModule} from "@angular/material/table";

@NgModule({
    declarations: [StudentsDataComponent],
    imports: [
       CommonModule,
       RouterModule.forChild([{path: '', component: StudentsDataComponent}]),
        NbCardModule,
        MatTableModule,
        NbButtonModule
    ]
 })
 export class StudentsDataModule {
 }