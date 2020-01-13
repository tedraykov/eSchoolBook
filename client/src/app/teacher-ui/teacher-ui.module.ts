import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from "@angular/router";

const teacherUiModuleRoutes: Routes = [
   {
      path: '',
      redirectTo: 'subject',
      pathMatch: 'full'
   },
   {
      path: 'subject',
      loadChildren: () => import('./subject-list/subject-list.module').then(m => m.SubjectListModule)
   },
   {
      path: 'subject/:id',
      loadChildren: () => import('./active-subject/active-subject.module').then(m => m.ActiveSubjectModule)
   }
];

@NgModule({
   declarations: [],
   imports: [
      CommonModule,
      RouterModule.forChild(teacherUiModuleRoutes)
   ],
   providers: []
})
export class TeacherUiModule {
}
