import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { TeachersDataComponent } from './teachers-data.component';
import {NbButtonModule, NbCardModule} from "@nebular/theme";
import {MatTableModule} from "@angular/material/table";

@NgModule({
    declarations: [TeachersDataComponent],
    imports: [
       CommonModule,
       RouterModule.forChild([{path: '', component: TeachersDataComponent}]),
        NbCardModule,
        MatTableModule,
        NbButtonModule
    ]
 })
 export class TeachersDataModule {
 }