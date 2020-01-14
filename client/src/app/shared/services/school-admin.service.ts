import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {SchoolUserInputModel} from "../../admin-ui/models/school-user.model";

@Injectable({
  providedIn: 'root'
})
export class SchoolAdminService {
  private readonly serverUrl = "http://localhost:5000";
  private readonly schoolAdminEndpoint = "admin";

  constructor(private http: HttpClient) {
  }

  addSchoolAdmin$(admin: SchoolUserInputModel) {
    return this.http.post(`${this.serverUrl}/${this.schoolAdminEndpoint}`, admin);
  }
}
