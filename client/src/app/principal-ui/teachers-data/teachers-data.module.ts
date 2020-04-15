import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { TeachersDataComponent } from './teachers-data.component';
import {NbButtonModule, NbCardModule, NbDialogModule, NbTabsetModule} from "@nebular/theme";
import {MatTableModule} from "@angular/material/table";
import { TeacherDialogComponent } from './teacher-dialog/teacher-dialog.component';

@NgModule({
    declarations: [
        TeachersDataComponent, 
        TeacherDialogComponent
    ],
    imports: [
        CommonModule,
        RouterModule.forChild([{path: '', component: TeachersDataComponent}]),
        NbDialogModule.forChild(),
        NbCardModule,
        MatTableModule,
        NbButtonModule,
        NbTabsetModule
    ],
    entryComponents: [
        TeacherDialogComponent
    ]
 })
 export class TeachersDataModule {
 }