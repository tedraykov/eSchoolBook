import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ParentsDataComponent } from './parents-data.component';
import {NbButtonModule, NbCardModule} from "@nebular/theme";
import {MatTableModule} from "@angular/material/table";

@NgModule({
    declarations: [ParentsDataComponent],
    imports: [
       CommonModule,
       RouterModule.forChild([{path: '', component: ParentsDataComponent}]),
        NbCardModule,
        MatTableModule,
        NbButtonModule
    ]
 })
 export class ParentsDataModule {
 }