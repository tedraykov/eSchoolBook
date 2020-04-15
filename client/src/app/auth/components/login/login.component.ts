import { Component, OnInit } from '@angular/core';
import { LoginModel } from "../../model/login.model";
import { Store } from "@ngrx/store";
import { Login } from "../../state/auth.actions";
import { AuthState } from "../../state";
import { userCredentials } from "./mocked-user-credentials";

@Component({
   selector: 'app-login',
   templateUrl: 'login.html',
   styleUrls: ['login.scss']
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

   loginAs(index: number) {
      this.user = userCredentials[index];
      this.login();
   }
}
