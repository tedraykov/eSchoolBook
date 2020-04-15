import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {RouterModule, Routes} from "@angular/router";
import {PrincipalStatisticsModule} from "../principal-ui/statistics/principal-statistics.module";

const routes: Routes = [
    {path: '', redirectTo: 'statistics', pathMatch: 'full'},
    {
        path: 'statistics',
        loadChildren: () => import('../principal-ui/statistics/principal-statistics.module')
            .then(m => m.PrincipalStatisticsModule)
    },
    {
        path: 'subjects',
        loadChildren: () => import('./subjects-list/subjects.module').then(m => m.SubjectsModule)
    },
    {
        path: 'classes',
        loadChildren: () => import('./classes-list/classes.module').then(m => m.ClassesModule)
    },
];

@NgModule({
    declarations: [],
    imports: [
        CommonModule,
        RouterModule.forChild(routes),
        PrincipalStatisticsModule
    ]
})
export class SchoolAdminUiModule {
}
