import { Component, OnDestroy, OnInit } from '@angular/core';
import { Store } from "@ngrx/store";
import { Subscription } from "rxjs";
import { AuthState, getAuthState } from "../../../auth/state";
import { tap } from "rxjs/operators";

interface AvatarUserModel {
   name: string,
   title: string
}

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
      this.sub = this.store.select(getAuthState).pipe(
            tap(x => console.log(x))
      ).subscribe(
      );
   }

   ngOnDestroy(): void {
      this.sub.unsubscribe();
   }

}
