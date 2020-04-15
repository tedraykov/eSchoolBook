import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from "@angular/router";
import { ActiveSubjectComponent } from './active-subject.component';
import { NbButtonModule, NbCardModule } from "@nebular/theme";
import { SubjectSummaryComponent } from './subject-detail/subject-summary.component';
import { StudentsListComponent } from './students-list/students-list.component';
import { MatTableModule } from "@angular/material/table";
import { GradeBadgeModule } from "../../shared/components/grade/grade-badge.module";

@NgModule({
   declarations: [
      ActiveSubjectComponent,
      SubjectSummaryComponent,
      StudentsListComponent],
   imports: [
      CommonModule,
      RouterModule.forChild([{path: '', component: ActiveSubjectComponent}]),
      NbCardModule,
      MatTableModule,
      GradeBadgeModule,
      NbButtonModule
   ]
})
export class ActiveSubjectModule {
}
