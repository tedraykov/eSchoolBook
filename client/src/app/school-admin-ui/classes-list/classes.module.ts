import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {ClassesListComponent} from "./classes-list.component";
import {NbButtonModule, NbCardModule} from "@nebular/theme";
import {MatTableModule} from "@angular/material/table";
import {RouterModule} from "@angular/router";
import {AddClassComponent} from "../add-class/add-class.component";
import {MatSortModule} from "@angular/material/sort";

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
            {path: 'add', component:AddClassComponent}
            ]),
        MatTableModule,
        MatSortModule,
        NbCardModule,
        NbButtonModule
    ]
})
export class ClassesModule {
}
