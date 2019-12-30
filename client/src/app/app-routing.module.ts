import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';


const routes: Routes = [
   {
      path: 'users',
      loadChildren: () => import('./user-ui/user-ui.module').then(m => m.UsersUiModule),
   },
   {
      path: 'teacher',
      loadChildren: () => import('./teacher-ui/teacher-ui.module').then(m => m.TeacherUiModule)
   }
];

@NgModule({
   imports: [RouterModule.forRoot(routes)],
   exports: [RouterModule]
})
export class AppRoutingModule {
}
