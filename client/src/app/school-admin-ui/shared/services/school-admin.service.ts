import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from "rxjs";
import {SubjectViewModel} from "../models/subject-view.model";
import {SubjectInputModel} from "../models/subject-input.model";
import {MinimalSchoolUser} from "../../../shared/models/minimal-school-user.interface";

@Injectable({providedIn: "root"})
export class SchoolAdminService {
    private readonly serverUrl = "http://localhost:5000";

    constructor(private http: HttpClient) {
    }

    /*Get all subjects in school*/
    public getAllSubjects$(): Observable<SubjectViewModel[]>{
        return this.http.get<SubjectViewModel[]>(`${this.serverUrl}/subject`);
    };

    /*Get all subjects for a grade (e.g. get subject for first graders)*/
    public getAllSubjectsByGrade$(grade: number): Observable<SubjectViewModel[]>{
        return this.http.get<SubjectViewModel[]>(`${this.serverUrl}/subject/grade/${grade}`);
    }

    /*Get single subject details*/
    public getSubjectDetails$(subjectId: string): Observable<SubjectViewModel>{
        return this.http.get<SubjectViewModel>(`${this.serverUrl}/subject/id/${subjectId}`);
    }

    /*Delete subject*/
    public deleteSubject$(subjectId: string){
        return this.http.request('delete',`${this.serverUrl}/subject/${subjectId}`);
    }

    /*Edit subject*/
    public editSubject$(subjectId: string, data: SubjectInputModel){
        return this.http.put(`${this.serverUrl}/subject/${subjectId}`, data);
    }

    /*Edit subject*/
    public addSubject$(data: SubjectInputModel){
        return this.http.post(`${this.serverUrl}/subject/`, data);
    }

    /*Get all teachers from school*/
    public getAllTeachers$(schoolId: string): Observable<MinimalSchoolUser[]>{
        return this.http.get<MinimalSchoolUser[]>(`${this.serverUrl}/teacher/dropdown/${schoolId}`);
    }

    /*Get all teachers from school*/
    public getAllTeachersForSubject$(subjectId: string): Observable<MinimalSchoolUser[]>{
        return this.http.get<MinimalSchoolUser[]>(`${this.serverUrl}/teacher/subject/${subjectId}`);
    }

    /*Add teacher to Subject's teacher list*/
    public addTeacherToSubject$(subjectId: string, teacherId: string): Observable<any>{
        return this.http.post(`${this.serverUrl}/subject/teacher/${subjectId}`, JSON.stringify(teacherId));
    }

    /*Remove teacher from Subject's teacher list*/
    public removeTeacherFromSubject$(subjectId: string, teacherId: string){
        return this.http.request('delete',`${this.serverUrl}/subject/teacher/${subjectId}`, 
            {body: JSON.stringify(teacherId)});
    }
}
