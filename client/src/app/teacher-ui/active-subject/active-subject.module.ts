import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from "@angular/router";
import { SubjectDetailsComponent } from './subject-details.component';


@NgModule({
   declarations: [SubjectDetailsComponent],
   imports: [
      CommonModule,
      RouterModule.forChild([{path: '', component: SubjectDetailsComponent}])
   ]
})
export class ActiveSubjectModule {
}
