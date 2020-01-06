import { Component, OnDestroy, OnInit } from '@angular/core';
import { Store } from "@ngrx/store";
import { Subscription } from "rxjs";
import { AuthState, avatarUser } from "../../../auth/state";
import { AvatarUserModel } from "./avatar-user.model";
import { NbMenuService } from "@nebular/theme";
import { filter, map } from "rxjs/operators";
import { Logout } from "../../../auth/state/auth.actions";

@Component({
   selector: 'app-user-avatar',
   templateUrl: './user-avatar.component.html',
   styleUrls: ['./user-avatar.component.scss']
})
export class UserAvatarComponent implements OnInit, OnDestroy {
   user: AvatarUserModel;
   sub: Subscription;
   contextMenuItems = [
      {title: 'Logout'}
   ];
   readonly contextMenuName = 'user-avatar-context-menu';

   constructor(
         private store: Store<AuthState>,
         private nbMenuService: NbMenuService) {
   }

   ngOnInit() {
      this.sub = this.store.select(avatarUser)
            .subscribe(avatarUser => this.user = avatarUser);
      this.nbMenuService.onItemClick().pipe(
            filter(({tag}) => tag === this.contextMenuName),
            map(({item: {title}}) => title),
      ).subscribe(
            menuItem => {
               if (menuItem === 'Logout') {
                  this.store.dispatch(new Logout());
               }
            }
      )
   }

   ngOnDestroy(): void {
      this.sub.unsubscribe();
   }

}
