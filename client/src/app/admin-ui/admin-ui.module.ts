import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {RouterModule, Routes} from "@angular/router";
import {CreateUserComponent} from './create-user/create-user.component';
import {
    NbButtonModule,
    NbCardModule, NbIconModule,
    NbInputModule,
    NbListModule,
    NbSelectModule,
    NbStepperModule
} from "@nebular/theme";
import {ReactiveFormsModule} from "@angular/forms";
import { CreateStudentComponent } from './create-user/create-student/create-student.component';
import {CreateTeacherComponent} from "./create-user/create-teacher/create-teacher.component";
import { NewUserSummaryComponent } from './create-user/new-user-summary/new-user-summary.component';
import { CreatePrincipalComponent } from './create-user/create-principal/create-principal.component';
import { CreateParentComponent } from './create-user/create-parent/create-parent.component';

const adminUiModuleRoutes: Routes = [
    {path: '', pathMatch: 'full', redirectTo: 'create'},
    {path: 'create', component: CreateUserComponent}
];

@NgModule({
    declarations: [CreateUserComponent, CreateStudentComponent, CreateTeacherComponent, NewUserSummaryComponent, CreatePrincipalComponent, CreateParentComponent],
    imports: [
        CommonModule,
        ReactiveFormsModule,
        RouterModule.forChild(adminUiModuleRoutes),
        NbCardModule,
        NbInputModule,
        NbStepperModule,
        NbSelectModule,
        NbButtonModule,
        NbListModule,
        NbIconModule
    ]
})
export class AdminUiModule {
}
