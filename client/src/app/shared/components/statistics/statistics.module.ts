import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {D3AdvancedPieComponent} from "./d3-advanced-pie/d3-advanced-pie.component";
import {AverageScoreComponent} from "./average-score/average-score.component";
import {NbCardModule, NbListModule, NbThemeService} from "@nebular/theme";
import {NgxChartsModule} from "@swimlane/ngx-charts";
import {CategoryAverageScoreComponent} from './category-average-score/category-average-score.component'

const components = [
    AverageScoreComponent,
    D3AdvancedPieComponent,
    CategoryAverageScoreComponent
];

@NgModule({
    declarations: [...components],
    imports: [
        CommonModule,
        NbCardModule,
        NbListModule,
        NgxChartsModule
    ],
    exports: [...components],
    providers: [
        NbThemeService
    ]
})
export class StatisticsModule {
}
