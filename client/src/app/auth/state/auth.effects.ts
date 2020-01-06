import {
   AuthActionTypes, InitializeStateComplete,
   Login,
   LoginFailed,
   LoginSuccess
} from "./auth.actions";
import { Actions, Effect, ofType } from "@ngrx/effects";
import { catchError, map, switchMap, tap } from "rxjs/operators";
import { LoginModel } from "../model/login.model";
import { AuthService } from "../services/auth.service";
import { of } from "rxjs";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";

@Injectable()
export class AuthEffects {
   @Effect()
   public Login = this.actions$.pipe(
         ofType(AuthActionTypes.Login),
         map((action: Login) => action.payload),
         switchMap((user: LoginModel) => {
            return this.authService.login(user).pipe(
                  map(x => {
                     return new LoginSuccess(x);
                  }),
                  catchError(x => {
                     console.error(x);
                     return of(new LoginFailed(x));
                  })
            );
         })
   );

   @Effect({dispatch: false})
   LogInSuccess = this.actions$.pipe(
         ofType(AuthActionTypes.LoginSuccess),
         tap((success: LoginSuccess) => {
            localStorage.setItem('token', success.payload.token);
            this.router.navigateByUrl('/').then();
         })
   );

   @Effect()
   InitializeState = this.actions$.pipe(
         ofType(AuthActionTypes.InitializeState),
         map(() => this.authService.getAuthState()),
         map(x => {
            return new InitializeStateComplete(x);
         })
   );

   @Effect({dispatch: false})
   Logout = this.actions$.pipe(
         ofType(AuthActionTypes.Logout),
         tap(() => {
                  localStorage.removeItem('token');
                  this.router.navigate(['auth']).then();
               }
         )
   );

   constructor(private actions$: Actions, private authService: AuthService, private router: Router) {
   }
}

