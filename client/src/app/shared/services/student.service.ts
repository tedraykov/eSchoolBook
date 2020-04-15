import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {MinimalStudent} from "../models/minimal-student.model";
import { tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class StudentService {
    readonly url = environment.serverUrl;
    private readonly endpoint = 'students';

    constructor(private http: HttpClient) {
    }

    getAllStudentsBySchool$(schoolId: string): Observable<MinimalStudent[]> {
        return this.http.get<MinimalStudent[]>(`${this.url}/${this.endpoint}/school/${schoolId}`);
    }
}
