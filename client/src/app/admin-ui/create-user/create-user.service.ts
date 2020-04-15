import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { StudentInputModel } from './models/student-input.model';
import { SchoolUserInputModel } from '../models/school-user.model';
import { ParentInputModel } from './models/parent-input.model';
import { environment } from 'src/environments/environment';

@Injectable()
export class CreateUserService {
  private readonly serverUrl = environment.serverUrl;
  private readonly teacherEndpoint = 'teacher';
  private readonly studnetEndpoint = 'studnet';
  private readonly principalEndpoint = 'principal';
  private readonly adminEndpoint = 'admin';
  private readonly parentEndpoint = 'parent';


  constructor(private http: HttpClient) { }

  addStudent$(student: StudentInputModel) {
    return this.http.post(`${this.serverUrl}/${this.studnetEndpoint}`, student);
  }

  addTeacher$(teacher: SchoolUserInputModel) {
    return this.http.post(`${this.serverUrl}/${this.teacherEndpoint}`, teacher);
  }

  addPrincipal$(principal: SchoolUserInputModel) {
    return this.http.post(`${this.serverUrl}/${this.principalEndpoint}`, principal);
  }

  addAdmin$(admin: SchoolUserInputModel) {
    return this.http.post(`${this.serverUrl}/${this.adminEndpoint}`, admin);
  }

  addParent$(parent: ParentInputModel) {
    return this.http.post(`${this.serverUrl}/${this.parentEndpoint}`, parent);
  }
}
