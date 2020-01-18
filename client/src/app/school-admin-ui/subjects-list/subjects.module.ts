import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {SubjectsComponent} from "./subjects.component";
import {RouterModule} from "@angular/router";
import {AddSubjectComponent} from "../add-subject/add-subject.component";
import {
    NbAccordionModule,
    NbButtonModule,
    NbCardModule, NbDialogService, NbIconModule, NbInputModule,
    NbListModule,
    NbSelectModule,
    NbTabsetModule, NbTooltipModule
} from "@nebular/theme";
import {DialogsModule} from "../../shared/components/dialogs/dialogs.module";
import {ReactiveFormsModule} from "@angular/forms";

@NgModule({
    declarations: [
        SubjectsComponent,
        AddSubjectComponent
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
        AddSubjectComponent
    ],
    providers: [
        NbDialogService
    ]
})
export class SubjectsModule {
}
