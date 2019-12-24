import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from "@angular/router";
import { UsersListComponent } from "./users-list/users-list.component";
import { NbCardModule, NbTreeGridModule } from "@nebular/theme";
import { UserComponent } from './user/user.component';

const userUiModuleRoutes: Routes = [
   {path: '', component: UsersListComponent},
   {path: ':id', component: UserComponent}
];

@NgModule({
   declarations: [UsersListComponent, UserComponent],
   imports: [
      CommonModule,
      RouterModule.forChild(userUiModuleRoutes),
      NbCardModule,
      NbTreeGridModule,
   ],
   providers: []
})
export class UsersUiModule {
}
