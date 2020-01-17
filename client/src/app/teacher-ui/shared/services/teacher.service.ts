import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable, of } from "rxjs";
import { Subject } from "../models/subject";
import { subjects } from "./mocked-subjects";

@Injectable({
    providedIn: 'root'
})
export class TeacherService {
   private readonly serverUrl = "http://localhost:5000";
   private readonly teacherEndpoint = "teacher";

   constructor(private http: HttpClient) {
   }

   public getSubjectsFromCurriculum$(teacherId: string): Observable<Subject[]> {
      //TODO implement get request for all subjects that teacher teaches

      // return this.http.get<Subject[]>(this.serverUrl + '/subject/teacher/' + teacherId);

      // Mocked implementation
      return of(subjects);
   }
}
