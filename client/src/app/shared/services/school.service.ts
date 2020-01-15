import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {School} from "../models/school.interface";
import {SchoolInputModel} from "../../admin-ui/add-school/models/school-input.model";

@Injectable({
  providedIn: 'root'
})
export class SchoolService {
  readonly url = 'http://localhost:5000';
  private readonly schoolEndpoint = 'school';
  constructor(private http: HttpClient) { }

  getAllSchools$(): Observable<School[]> {
    return this.http.get<School[]>(`${this.url}/${this.schoolEndpoint}`);
  }

  addSchool$(school: SchoolInputModel): Observable<void> {
    return this.http.post<void>(`${this.url}/${this.schoolEndpoint}`, school);
  }
}
