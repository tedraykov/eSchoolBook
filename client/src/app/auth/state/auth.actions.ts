import { Action } from '@ngrx/store';
import { LoginModel } from "../model/login.model";
import { AuthUserModel } from "../model/auth.user.model";
import { AuthState } from "./index";

export enum AuthActionTypes {
   InitializeState = '[Auth] Initialize State',
   InitializeStateComplete = '[Auth] Initialize State Complete',
   Login = '[Auth] Login',
   LoginSuccess = '[Auth] Login Success',
   LoginFailed = '[Auth] Login Failed',
   Logout = '[Auth] Logout'
}

export class Login implements Action {
   readonly type = AuthActionTypes.Login;

   constructor(public payload: LoginModel) {
   }
}

export class LoginSuccess implements Action {
   readonly type = AuthActionTypes.LoginSuccess;

   constructor(public payload: AuthUserModel) {
   }

}

export class LoginFailed implements Action {
   readonly type = AuthActionTypes.LoginFailed;

   constructor(public payload: any) {
   }
}

export class Logout implements Action {
   readonly type = AuthActionTypes.Logout;
}

export class InitializeState implements Action {
   readonly type = AuthActionTypes.InitializeState;

   constructor() {
   }
}

export class InitializeStateComplete implements Action {
   readonly type = AuthActionTypes.InitializeStateComplete;

   constructor(public payload: AuthState) {
   }
}

export type AuthActions =
      LoginSuccess
      | LoginFailed
      | InitializeStateComplete
      | Logout;
