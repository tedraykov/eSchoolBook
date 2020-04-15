import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {tap} from "rxjs/operators";
import {StringDoubleModel} from "../models/string-double.model";
import { environment } from 'src/environments/environment';


@Injectable({
    providedIn: "root"
    })
export class StatisticsService {
    private readonly serverUrl = environment.serverUrl;

    constructor(private http: HttpClient) {
    }

    /*Get school average score*/
    public getSchoolAverageScore$(schoolId: string): Observable<number>{
        return this.http.get<number>(`${this.serverUrl}/school-score/${schoolId}`);
    };

    /*Get school absences*/
    public getSchoolAbsences$(schoolId: string): Observable<Array<StringDoubleModel>>{
        return this.http.get<Array<StringDoubleModel>>(`${this.serverUrl}/school-absences/${schoolId}`);
    };

    /*Get school teachers average score*/
    public getSchoolTeachersAverageScore$(schoolId: string): Observable<Array<StringDoubleModel>>{
        return this.http.get<Array<StringDoubleModel>>(`${this.serverUrl}/teachers-score/${schoolId}`);
    };

    /*Get school subjects average score*/
    public getSchoolSubjectsAverageScore$(schoolId: string): Observable<Array<StringDoubleModel>>{
        return this.http.get<Array<StringDoubleModel>>(`${this.serverUrl}/subjects-score/${schoolId}`);
    };
}
