import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {ConfirmationDialogComponent} from "./confirmation-dialog/confirmation-dialog.component";
import {NbButtonModule, NbCardModule, NbDialogModule, NbIconModule} from "@nebular/theme";
import {MatDialogModule} from "@angular/material/dialog";
import {MatButtonModule} from "@angular/material/button";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import {BrowserModule} from "@angular/platform-browser";

const dialogComponents = [
    ConfirmationDialogComponent
];

@NgModule({
    declarations: [...dialogComponents],
    imports: [
        CommonModule,
        NbCardModule,
        NbDialogModule,
        NbButtonModule,
        NbIconModule
    ],
    entryComponents: [...dialogComponents]
})
export class DialogsModule {
}
