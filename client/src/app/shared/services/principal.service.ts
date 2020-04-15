import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {SchoolUserInputModel} from "../../admin-ui/models/school-user.model";
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: "root"
})
export class PrincipalService {
   private readonly serverUrl = environment.serverUrl;
   private readonly principalEndpoint = "principal";

   constructor(private http: HttpClient) {
   }

    addPrincipal$(principal: SchoolUserInputModel) {
        return this.http.post(`${this.serverUrl}/${this.principalEndpoint}`, principal);
    }
}
