import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
   NbActionsModule,
   NbLayoutModule,
   NbSidebarModule
} from "@nebular/theme";
import { LayoutComponent } from './layout.component';
import { HeaderComponent } from './header/header.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { ContentComponent } from './content/content.component';
import { RouterModule } from "@angular/router";


@NgModule({
   declarations: [LayoutComponent, HeaderComponent, SidebarComponent, ContentComponent],
   exports: [
      LayoutComponent
   ],
   imports: [
      CommonModule,
      NbLayoutModule,
      NbSidebarModule,
      RouterModule,
      NbActionsModule
   ]
})
export class LayoutModule {
}
