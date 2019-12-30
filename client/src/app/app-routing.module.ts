import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NbAuthComponent, NbLoginComponent, } from '@nebular/auth';
import { LayoutComponent } from "./layout/layout.component";

const routes: Routes = [
   {
      path: '', pathMatch: 'full', component: LayoutComponent,
      children: [
         {
            path: 'users',
            loadChildren: () => import('./user-ui/user-ui.module').then(m => m.UsersUiModule),
         },
         {
            path: 'teacher',
            loadChildren: () => import('./teacher-ui/teacher-ui.module').then(m => m.TeacherUiModule)
         }
      ]
   },
   {
      path: 'auth',
      component: NbAuthComponent,
      children: [
         {
            path: '',
            component: NbLoginComponent,
         },
         {
            path: 'login',
            component: NbLoginComponent,
         }
      ],
   },
];

@NgModule({
   imports: [RouterModule.forRoot(routes)],
   exports: [RouterModule]
})
export class AppRoutingModule {
}
