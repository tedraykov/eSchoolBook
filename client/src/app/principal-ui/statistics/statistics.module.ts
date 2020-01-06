import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { StatisticsComponent } from './statistics.component';
import { NgxEchartsModule } from 'ngx-echarts';

@NgModule({
    declarations: [],
    imports: [
       CommonModule,
       RouterModule.forChild([{path: '', component: StatisticsComponent}]),
       NgxEchartsModule 
    ]
 })
 export class StatisticsModule {
 }