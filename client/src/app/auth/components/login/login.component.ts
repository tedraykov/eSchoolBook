import { Component, OnInit } from '@angular/core';
import { LoginModel } from "../../model/login.model";
import { Store } from "@ngrx/store";
import { Login } from "../../state/auth.actions";
import { AuthState } from "../../state";

@Component({
   selector: 'app-login',
   templateUrl: 'login.html',
   styles: []
})
export class LoginComponent implements OnInit {
   user: LoginModel;
   submitted: boolean = false;

   public constructor(private store: Store<AuthState>) {
   }

   ngOnInit(): void {
      this.user = {email: '', password: ''};
   }

   login() {
      this.store.dispatch(new Login(this.user));
   }
}
