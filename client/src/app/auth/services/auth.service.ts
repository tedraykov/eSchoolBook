import { Injectable } from '@angular/core';
import { LoginModel } from "../model/login.model";
import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";
import { AuthUserModel } from "../model/auth.user.model";
import { map } from "rxjs/operators";
import { JwtHelperService } from '@auth0/angular-jwt';
import { JwtPayloadModel } from "../model/jwt.payload.model";
import { AuthState } from "../state";
import { Roles } from "../../shared/enums/school-user-roles";
import { initialState } from "../state/auth.reducer";
import { environment } from 'src/environments/environment';

@Injectable()
export class AuthService {
   private readonly baseUrl = environment.serverUrl;
   private readonly loginEndpoint = '/account/login';

   constructor(
         private http: HttpClient) {
   }

   private static jwtToModel(token: string): AuthUserModel {
      const decoded = AuthService.getTokenPayload(token);
      return {
         token,
         role: decoded.role,
         nameId: decoded.nameid,
         isAdmin: decoded.isAdmin,
         name: decoded.userNames,
         schoolId: decoded.schoolId
      };
   }

   private static getTokenPayload(token: string): JwtPayloadModel {
      const helper = new JwtHelperService();
      try {
         return helper.decodeToken(token);
      } catch (e) {
         throw new Error('Token is corrupted');
      }
   }

   getToken(): string {
      return localStorage.getItem('token');
   }

   hasTokenExpired(token: string): boolean {
      const payload = AuthService.getTokenPayload(token);
      return Date.now() > payload.exp;
   }

   login(user: LoginModel): Observable<AuthUserModel> {
      return this.http.post<any>(this.baseUrl + this.loginEndpoint, user).pipe(
            map((jwt: { accessToken: string }) => jwt.accessToken),
            map(AuthService.jwtToModel));
   }

   getAuthState(): AuthState {
      const token = this.getToken();
      if (token && this.hasTokenExpired(token)) {
         const payload = AuthService.getTokenPayload(token);
         return <AuthState>{
            name: payload.userNames,
            isAuthenticated: true,
            role: Roles[payload.role],
            token: token,
            userId: payload.nameid,
            schoolId: payload.schoolId
         }
      }
      return initialState;
   }
}
