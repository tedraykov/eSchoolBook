import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {RouterModule} from '@angular/router';
import {ParentsDataComponent} from './parents-data.component';
import {NbButtonModule, NbCardModule, NbDialogModule, NbTabsetModule} from "@nebular/theme";
import {MatTableModule} from "@angular/material/table";
import {ParentDialogComponent} from "./parent-dialog/parent-dialog.component";

@NgModule({
    declarations: [
        ParentsDataComponent, 
        ParentDialogComponent
    ],
    imports: [
        CommonModule,
        RouterModule.forChild([{path: '', component: ParentsDataComponent}]),
        NbDialogModule.forChild(),
        NbCardModule,
        MatTableModule,
        NbButtonModule,
        NbTabsetModule
    ],
    entryComponents: [
        ParentDialogComponent
    ]
 })
 export class ParentsDataModule {
 }