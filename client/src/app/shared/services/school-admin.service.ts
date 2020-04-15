import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {SchoolUserInputModel} from "../../admin-ui/models/school-user.model";
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SchoolAdminService {
  private readonly serverUrl = environment.serverUrl;
  private readonly schoolAdminEndpoint = "admin";

  constructor(private http: HttpClient) {
  }

  addSchoolAdmin$(admin: SchoolUserInputModel) {
    return this.http.post(`${this.serverUrl}/${this.schoolAdminEndpoint}`, admin);
  }
}
