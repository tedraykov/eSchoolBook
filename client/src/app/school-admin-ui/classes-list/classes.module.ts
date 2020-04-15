import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {ClassesListComponent} from "./classes-list.component";
import {
    NbAlertModule,
    NbButtonModule,
    NbCardModule,
    NbDialogService,
    NbIconModule,
    NbInputModule,
    NbListModule,
    NbSelectModule
} from "@nebular/theme";
import {MatTableModule} from "@angular/material/table";
import {RouterModule} from "@angular/router";
import {AddClassComponent} from "../add-class/add-class.component";
import {MatSortModule} from "@angular/material/sort";
import {ReactiveFormsModule} from "@angular/forms";
import {DialogsModule} from "../../shared/components/dialogs/dialogs.module";

const classComponents = [
    ClassesListComponent,
    AddClassComponent
];

@NgModule({
    declarations: [...classComponents],
    imports: [
        CommonModule,
        RouterModule.forChild([
            {path: '', component: ClassesListComponent},
            {path: 'add', component: AddClassComponent}
            ]),
        MatTableModule,
        MatSortModule,
        NbCardModule,
        NbButtonModule,
        NbSelectModule,
        NbListModule,
        NbIconModule,
        ReactiveFormsModule,
        NbInputModule,
        DialogsModule,
        NbAlertModule
    ],
    providers: [
        NbDialogService
    ]
})
export class ClassesModule {
}
