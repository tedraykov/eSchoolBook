import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {SubjectsComponent} from "./subjects.component";
import {RouterModule} from "@angular/router";
import {AddSubjectComponent} from "../add-subject/add-subject.component";
import {
    NbButtonModule,
    NbCardModule,
    NbDialogService,
    NbIconModule,
    NbInputModule,
    NbListModule,
    NbSelectModule,
    NbTabsetModule,
    NbTooltipModule
} from "@nebular/theme";
import {DialogsModule} from "../../shared/components/dialogs/dialogs.module";
import {ReactiveFormsModule} from "@angular/forms";
import {ConfigureSubjectTeacherComponent} from "../configure-subject-teacher/configure-subject-teacher.component";

@NgModule({
    declarations: [
        SubjectsComponent,
        AddSubjectComponent,
        ConfigureSubjectTeacherComponent
    ],
    imports: [
        CommonModule,
        RouterModule.forChild([{path: '', component: SubjectsComponent}]),
        NbCardModule,
        NbSelectModule,
        NbListModule,
        NbTabsetModule,
        NbButtonModule,
        NbIconModule,
        DialogsModule,
        ReactiveFormsModule,
        NbTooltipModule,
        NbInputModule
    ],
    entryComponents: [
        AddSubjectComponent,
        ConfigureSubjectTeacherComponent
    ],
    providers: [
        NbDialogService
    ]
})
export class SubjectsModule {
}
