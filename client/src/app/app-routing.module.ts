import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';


const routes: Routes = [
   {
      path: 'users',
      loadChildren: () => import('./user-ui/user-ui.module').then(m => m.UsersUiModule)
   }
];

@NgModule({
   imports: [RouterModule.forRoot(routes)],
   exports: [RouterModule]
})
export class AppRoutingModule {
}
