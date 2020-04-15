import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from "rxjs";
import {SchoolUsersTableData} from "../models/SchoolUsersTableData";
import {StudentDialogData} from "../models/StudentDialogData";
import {ParentData} from "../models/ParentData";
import {TeacherDialogData} from "../models/TeacherDialogData";
import { environment } from 'src/environments/environment';

@Injectable()
export class PrincipalService {
   private readonly serverUrl = environment.serverUrl;

   constructor(private http: HttpClient) {
   }
   /*Get all students in school*/
   public getStudentsData$(schoolId: string): Observable<SchoolUsersTableData[]>{
      return this.http.get<SchoolUsersTableData[]>(`${this.serverUrl}/students/school/${schoolId}`);
   };

   /*Get single student data*/
   public getStudentData$(studentId: string): Observable<StudentDialogData>{
      return this.http.get<StudentDialogData>(`${this.serverUrl}/students/dialog/${studentId}`);
   };
   
   /*Get all teachers in school*/
   public getTeachersData$(schoolId: string): Observable<SchoolUsersTableData[]>{
      return this.http.get<SchoolUsersTableData[]>(`${this.serverUrl}/teacher/school/${schoolId}`);
   };

   /*Get single teacher data*/
   public getTeacherData$(teacherId: string): Observable<TeacherDialogData>{
      return this.http.get<TeacherDialogData>(`${this.serverUrl}/teacher/dialog/${teacherId}`);
   };

   /*Get all parents in school*/
   public getParentsData$(schoolId: string): Observable<ParentData[]>{
      return this.http.get<ParentData[]>(`${this.serverUrl}/parent/school/${schoolId}`);
   };

   /*Get single parent data*/
   public getParentData$(parentId: string): Observable<ParentData>{
      return this.http.get<ParentData>(`${this.serverUrl}/parent/dialog/${parentId}`);
   };
}
