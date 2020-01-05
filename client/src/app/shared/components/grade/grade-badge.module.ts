import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GradeBadgeComponent } from "./grade-badge.component";


@NgModule({
   declarations: [GradeBadgeComponent],
   imports: [
      CommonModule
   ],
   exports: [GradeBadgeComponent]
})
export class GradeBadgeModule {
}
