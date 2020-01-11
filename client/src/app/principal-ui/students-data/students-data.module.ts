import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {RouterModule} from '@angular/router';
import {StudentsDataComponent} from './students-data.component';
import {NbButtonModule, NbCardModule, NbDialogModule, NbTabsetModule} from "@nebular/theme";
import {MatTableModule} from "@angular/material/table";
import {StudentDialogComponent} from "./student-dialog/student-dialog.component";

@NgModule({
    declarations: [
        StudentsDataComponent,
        StudentDialogComponent
    ],
    imports: [
        CommonModule,
        RouterModule.forChild([{path: '', component: StudentsDataComponent}]),
        NbDialogModule.forChild(),
        NbCardModule,
        MatTableModule,
        NbButtonModule,
        NbTabsetModule
    ],
    entryComponents: [
        StudentDialogComponent
    ]
 })
 export class StudentsDataModule {
 }