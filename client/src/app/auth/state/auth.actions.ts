import { Action } from '@ngrx/store';
import { LoginModel } from "../model/login.model";
import { AuthUserModel } from "../model/auth.user.model";

export enum AuthActionTypes {
   Login = '[Auth] Login',
   LoginSuccess = '[Auth] Login Success',
   LoginFailed = '[Auth] Login Failed'
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

export type AuthActions = LoginSuccess | LoginFailed;
