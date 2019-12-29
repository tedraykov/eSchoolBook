import { NgModule } from '@angular/core';
import { HoverableDirective } from "./hoverable.directive";


@NgModule({
   declarations: [HoverableDirective],
   exports: [HoverableDirective]
})
export class DirectivesModule {
}
