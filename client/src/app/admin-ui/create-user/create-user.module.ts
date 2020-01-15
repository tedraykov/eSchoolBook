import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {
    NbButtonModule,
    NbCardModule, NbIconModule,
    NbInputModule,
    NbListModule,
    NbSelectModule,
    NbStepperModule, NbUserModule
} from "@nebular/theme";
import {RouterModule} from "@angular/router";
import {ReactiveFormsModule} from "@angular/forms";

import {CreateUserComponent} from "./create-user.component";
import {CreateStudentComponent} from "./create-student/create-student.component";
import {CreatePrincipalComponent} from "./create-principal/create-principal.component";
import {CreateParentComponent} from "./create-parent/create-parent.component";
import {CreateAdminComponent} from "./create-admin/create-admin.component";
import {CreateTeacherComponent} from "./create-teacher/create-teacher.component";
import {NewUserSummaryComponent} from "./new-user-summary/new-user-summary.component";

@NgModule({
    declarations: [
        CreateUserComponent,
        CreateStudentComponent,
        CreateTeacherComponent,
        NewUserSummaryComponent,
        CreatePrincipalComponent,
        CreateParentComponent,
        CreateAdminComponent
    ],
    imports: [
        CommonModule,
        ReactiveFormsModule,
        RouterModule.forChild([{path: '', component: CreateUserComponent}]),
        NbCardModule,
        NbInputModule,
        NbStepperModule,
        NbSelectModule,
        NbButtonModule,
        NbListModule,
        NbIconModule,
        NbUserModule
    ]
})
export class CreateUserModule {
}
