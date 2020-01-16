import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {RouterModule} from '@angular/router';
import {NgxEchartsModule} from 'ngx-echarts';
import {PrincipalStatisticsComponent} from "./principal-statistics.component";
import {StatisticsModule} from "../../shared/components/statistics/statistics.module";

@NgModule({
    declarations: [PrincipalStatisticsComponent],
    imports: [
        CommonModule,
        RouterModule.forChild([{path: '', component: PrincipalStatisticsComponent}]),
        NgxEchartsModule,
        StatisticsModule
    ]
})
export class PrincipalStatisticsModule {
}