import { Roles } from "../../shared/enums/school-user-roles";
import { AuthActions, AuthActionTypes } from "./auth.actions";
import { createSelector } from "@ngrx/store";
import { AppState } from "../../state/app.state";
import { AuthState } from "./index";
import {AvatarUserModel} from "../../shared/components/user-avatar/avatar-user.model";

export const initialState: AuthState = {
   name: null,
   role: null,
   userId: null,
   schoolId: null,
   token: null,
   isAuthenticated: false
};

export function reducer(state = initialState, action: AuthActions): AuthState {
   switch (action.type) {
      case AuthActionTypes.LoginSuccess:
         return {
            ...state,
            token: action.payload.token,
            role: Roles[action.payload.role],
            userId: action.payload.nameId,
            name: action.payload.name,
            schoolId: action.payload.schoolId,
            isAuthenticated: true
         };
      case AuthActionTypes.InitializeStateComplete:
         return action.payload;
      case AuthActionTypes.Logout:
         return initialState;
      default:
         return state;
   }
}

const selectAuth = ((state: AppState) => state.auth);
export const selectRole = createSelector(selectAuth, (state: AuthState) => state.role);
export const selectSchoolId = createSelector(selectAuth, (state: AuthState) => state.schoolId);