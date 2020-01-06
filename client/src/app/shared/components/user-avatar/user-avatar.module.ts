import { NgModule } from '@angular/core';
import { UserAvatarComponent } from "./user-avatar.component";
import { NbContextMenuModule, NbUserModule } from "@nebular/theme";
import { CommonModule } from "@angular/common";

@NgModule({
   declarations: [UserAvatarComponent],
   imports: [
      NbUserModule,
      CommonModule,
      NbContextMenuModule
   ],
   entryComponents: [UserAvatarComponent],
   exports: [UserAvatarComponent]
})
export class UserAvatarModule {
}
