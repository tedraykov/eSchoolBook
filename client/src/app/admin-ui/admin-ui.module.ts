import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from "@angular/router";
import { AddSchoolComponent } from "./add-school/add-school.component";
import { NbButtonModule, NbInputModule, NbTooltipModule, NbCardModule } from "@nebular/theme";
import { ReactiveFormsModule } from "@angular/forms";
import { CreateUserService } from './create-user/create-user.service';

const adminUiModuleRoutes: Routes = [
    { path: '', pathMatch: 'full', redirectTo: 'create' },
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
        NbInputModule,
        NbButtonModule,
        NbCardModule,
        ReactiveFormsModule,
        NbTooltipModule
    ],
    providers: [CreateUserService]
})
export class AdminUiModule {
}
