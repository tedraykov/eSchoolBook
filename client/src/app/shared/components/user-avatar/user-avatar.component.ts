import { Component, OnDestroy, OnInit } from '@angular/core';
import { Store } from "@ngrx/store";
import { Subscription } from "rxjs";
import { AuthState, avatarUser } from "../../../auth/state";
import { AvatarUserModel } from "./avatar-user.model";

@Component({
   selector: 'app-user-avatar',
   templateUrl: './user-avatar.component.html',
   styleUrls: ['./user-avatar.component.scss']
})
export class UserAvatarComponent implements OnInit, OnDestroy {
   user: AvatarUserModel;
   sub: Subscription;

   constructor(private store: Store<AuthState>) {
   }

   ngOnInit() {
      this.sub = this.store.select(avatarUser)
            .subscribe(avatarUser => this.user = avatarUser);
   }

   ngOnDestroy(): void {
      this.sub.unsubscribe();
   }

}
