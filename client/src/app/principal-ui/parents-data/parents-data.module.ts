import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ParentsDataComponent } from './parents-data.component';

@NgModule({
    declarations: [ParentsDataComponent],
    imports: [
       CommonModule,
       RouterModule.forChild([{path: '', component: ParentsDataComponent}])
    ]
 })
 export class ParentsDataModule {
 }