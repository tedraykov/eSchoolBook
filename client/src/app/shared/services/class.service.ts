import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Class} from "../models/class.interface";
import {Observable} from "rxjs";
import {tap} from "rxjs/operators";
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class ClassService {
    readonly url = environment.serverUrl;
    private readonly endpoint = 'class';
    private readonly school = 'school';

    constructor(private http: HttpClient) {
    }

    getAllClasses$(schoolId: string): Observable<Class[]> {
        return this.http.get<Class[]>(`${this.url}/${this.endpoint}/${this.school}/${schoolId}`);
    }
}
