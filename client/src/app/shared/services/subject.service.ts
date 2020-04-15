import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable, of } from "rxjs";

@Injectable({
   providedIn: 'root'
})
export class SubjectService {

   constructor(private http: HttpClient) {
   }

   getStudentsInSubject$(subjectId: string): Observable<any> {
      return of();
   }
}
