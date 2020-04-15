import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Roles } from "../enums/school-user-roles";
import { environment } from 'src/environments/environment';

export interface UserModel {
   schoolUserId: string;
   fullName: string;
   role: Roles;
}

@Injectable({
   providedIn: 'root'
})
export class UserService {
   private readonly apiEndpoint = "api/users";

   constructor(private http: HttpClient) {
   }

   getUsers$(): Observable<UserModel[]> {
      return this.http.get<UserModel[]>(environment.serverUrl + this.apiEndpoint);
   }
}
