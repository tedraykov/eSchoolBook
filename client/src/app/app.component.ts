import { Component, OnInit } from '@angular/core';
import { AuthState } from "./auth/state";
import { Store } from "@ngrx/store";
import { InitializeState } from "./auth/state/auth.actions";

@Component({
   selector: 'app-root',
   template: `
      <router-outlet></router-outlet>`,
   styles: []
})
export class AppComponent implements OnInit {
   constructor(private authStore: Store<AuthState>) {
   }

   ngOnInit(): void {
      this.authStore.dispatch(new InitializeState());
   }
}
