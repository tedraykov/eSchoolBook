import { Injectable } from '@angular/core';
import { LoginModel } from "../model/login.model";
import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";
import { AuthUserModel } from "../model/auth.user.model";
import { map } from "rxjs/operators";
import { JwtHelperService } from '@auth0/angular-jwt';
import { JwtPayloadModel } from "../model/jwt.payload.model";

@Injectable()
export class AuthService {
   private readonly baseUrl = 'http://localhost:5000';
   private readonly loginEndpoint = '/account/login';

   constructor(
         private http: HttpClient) {
   }

   getToken(): string {
      return localStorage.getItem('token');
   }

   login(user: LoginModel): Observable<AuthUserModel> {
      return this.http.post<any>(this.baseUrl + this.loginEndpoint, user)
            .pipe(map(AuthService.jwtToModel));
   }

   private static jwtToModel(jwt: { accessToken: string }): AuthUserModel {
      const helper = new JwtHelperService();
      try {
         const decoded: JwtPayloadModel = helper.decodeToken(jwt.accessToken);
         return {
            token: jwt.accessToken,
            role: decoded.role,
            nameId: decoded.nameid,
            isAdmin: decoded.isAdmin
         };
      } catch (e) {
         throw e;
      }
   }
}
