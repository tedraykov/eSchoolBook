import { Roles } from "../../shared/enums/school-user-roles";
import { AuthActions, AuthActionTypes } from "./auth.actions";
import { createSelector } from "@ngrx/store";
import { AppState } from "../../state/app.state";
import { AuthState } from "./index";

export const initialState: AuthState = {
   role: null,
   userId: null,
   token: null,
   isAuthenticated: false
};

const selectAuth = ((state: AppState) => state.auth);
export const selectRole = createSelector(selectAuth, (state: AuthState) => state.role);

export function reducer(state = initialState, action: AuthActions): AuthState {
   switch (action.type) {
      case AuthActionTypes.LoginSuccess:
         return {
            ...state,
            token: action.payload.token,
            role: Roles[action.payload.role],
            userId: action.payload.nameId,
            isAuthenticated: true
         };
      case AuthActionTypes.InitializeStateComplete:
         return action.payload
   }
   return;
}
