import { Roles } from "../../shared/enums/school-user-roles";
import { createFeatureSelector } from "@ngrx/store";

export interface AuthState {
   role: Roles;
   token: string;
   userId: string;
   isAuthenticated: boolean;
}

export const getAuthState = createFeatureSelector('auth');

