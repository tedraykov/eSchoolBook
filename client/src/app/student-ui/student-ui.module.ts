import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from "@angular/router";

const studentUiModuleRoutes: Routes = [];

@NgModule({
   declarations: [],
   imports: [
      CommonModule,
      RouterModule.forChild(studentUiModuleRoutes)
   ]
})
export class StudentUiModule {
}
