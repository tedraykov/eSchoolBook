import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from "./layout/layout.component";

const routes: Routes = [
   {
      path: 'app', component: LayoutComponent,
      children: [
         {
            path: 'users',
            loadChildren: () => import('./user-ui/user-ui.module').then(m => m.UsersUiModule),
         },
         {
            path: 'teacher',
            loadChildren: () => import('./teacher-ui/teacher-ui.module').then(m => m.TeacherUiModule)
         },
         {
            path: 'student',
            loadChildren: () => import('./student-ui/student-ui.module').then(m => m.StudentUiModule)
         },
         {
            path: 'principal',
            loadChildren: () => import('./principal-ui/principal-ui.module').then(m => m.PrincipalUiModule)
         }
      ]
   },
   {path: '', pathMatch: 'full', redirectTo: 'app'}
];

@NgModule({
   imports: [RouterModule.forRoot(routes)],
   exports: [RouterModule]
})
export class AppRoutingModule {
}
