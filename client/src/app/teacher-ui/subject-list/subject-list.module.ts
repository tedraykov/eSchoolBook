import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SubjectListComponent } from './subject-list.component';
import { RouterModule } from "@angular/router";
import { NbButtonModule, NbCardModule } from "@nebular/theme";
import { MatTableModule } from "@angular/material/table";

@NgModule({
   declarations: [SubjectListComponent],
   imports: [
      CommonModule,
      RouterModule.forChild([{path: '', component: SubjectListComponent}]),
      NbCardModule,
      MatTableModule,
      NbButtonModule
   ]
})
export class SubjectListModule {
}
