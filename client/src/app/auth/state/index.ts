import { Roles } from "../../shared/enums/school-user-roles";
import { createFeatureSelector, createSelector } from "@ngrx/store";
import { AvatarUserModel } from "../../shared/components/user-avatar/avatar-user.model";

export interface AuthState {
   role: Roles;
   token: string;
   userId: string;
   isAuthenticated: boolean;
}

export const getAuthState = createFeatureSelector('auth');

export const avatarUser = createSelector(getAuthState, (state: AuthState) => {
   return <AvatarUserModel>{name: 'Not implemented yet', role: state.role}
});

