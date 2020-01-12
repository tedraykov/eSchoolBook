import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {RouterModule, Routes} from "@angular/router";
import {CreateUserComponent} from './create-user/create-user.component';
import {NbButtonModule, NbCardModule, NbInputModule, NbSelectModule, NbStepperModule} from "@nebular/theme";
import {ReactiveFormsModule} from "@angular/forms";
import { CreateStudentComponent } from './create-user/create-student/create-student.component';

const adminUiModuleRoutes: Routes = [
    {path: '', pathMatch: 'full', redirectTo: 'create'},
    {path: 'create', component: CreateUserComponent}
];

@NgModule({
    declarations: [CreateUserComponent, CreateStudentComponent],
    imports: [
        CommonModule,
        ReactiveFormsModule,
        RouterModule.forChild(adminUiModuleRoutes),
        NbCardModule,
        NbInputModule,
        NbStepperModule,
        NbSelectModule,
        NbButtonModule
    ]
})
export class AdminUiModule {
}
