import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable, of } from "rxjs";
import { Subject } from "../models/subject";
import { subjects } from "./mocked-subjects";

@Injectable()
export class TeacherService {

   constructor(http: HttpClient) {
   }

   public getSubjects$(): Observable<Subject[]> {
      //TODO implement get request for all subjects that teacher teaches

      // Mocked implementation
      return of(subjects);
   }
}
