import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
   NbActionsModule, NbIconModule,
   NbLayoutModule,
   NbMenuModule,
   NbSidebarModule, NbUserModule
} from "@nebular/theme";
import { LayoutComponent } from './layout.component';
import { HeaderComponent } from './header/header.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { ContentComponent } from './content/content.component';
import { RouterModule } from "@angular/router";
import { AppSettingsModule } from "../shared/components/app-settings/app-settings.module";
import { UserAvatarModule } from "../shared/components/user-avatar/user-avatar.module";


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
      NbActionsModule,
      NbMenuModule,
      AppSettingsModule,
      NbUserModule,
      UserAvatarModule,
      NbIconModule
   ]
})
export class LayoutModule {
}
