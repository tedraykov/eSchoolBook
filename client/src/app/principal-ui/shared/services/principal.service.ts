import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {Observable} from "rxjs";
import {StudentData} from "../models/StudentData";
import {tap} from "rxjs/operators";

@Injectable()
export class PrincipalService {
   private readonly serverUrl = "http://localhost:5000";

   constructor(private http: HttpClient) {
   }
   
   public getStudentsData$(schoolId: string): Observable<StudentData[]>{
      return this.http.get<StudentData[]>(`${this.serverUrl}/students/school/${schoolId}`).pipe(
          tap(x => console.log(x))
      );
   };
}
