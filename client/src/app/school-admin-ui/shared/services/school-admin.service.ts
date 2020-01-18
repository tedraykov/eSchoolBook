import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from "rxjs";
import {SubjectViewModel} from "../models/subject-view.model";
import {SubjectInputModel} from "../models/subject-input.model";
import {map} from "rxjs/operators";

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

    /*Get single subject details*/
    public removeTeacherFromSubject$(subjectId: string, teacherId: string){
        return this.http.request('delete',`${this.serverUrl}/subject/teacher/${subjectId}`, 
            {body: {teacherId: teacherId}});
    }
}
