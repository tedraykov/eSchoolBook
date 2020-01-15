import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {RouterModule, Routes} from "@angular/router";
import {AddSchoolComponent} from "./add-school/add-school.component";
import {NbButtonModule, NbCardModule, NbInputModule, NbTooltipModule} from "@nebular/theme";
import {ReactiveFormsModule} from "@angular/forms";

const adminUiModuleRoutes: Routes = [
    {path: '', pathMatch: 'full', redirectTo: 'create'},
    {
        path: 'user',
        children: [
            {
                path: 'create',
                loadChildren: () => import('./create-user/create-user.module').then(m => m.CreateUserModule)
            }
        ]
    },
    {
        path: 'school', children: [
            {
                path: 'add',
                component: AddSchoolComponent
            }
        ]
    }
];

@NgModule({
    declarations: [
        AddSchoolComponent
    ],
    imports: [
        CommonModule,
        RouterModule.forChild(adminUiModuleRoutes),
        NbCardModule,
        NbInputModule,
        NbButtonModule,
        ReactiveFormsModule,
        NbTooltipModule
    ]
})
export class AdminUiModule {
}
