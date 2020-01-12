import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {StudentInputModel} from "../../admin-ui/create-user/models/student-input.model";
import {tap} from "rxjs/operators";

@Injectable({
    providedIn: 'root'
})
export class StudentService {
    readonly url = 'http://localhost:5000';
    private readonly endpoint = 'students';

    constructor(private http: HttpClient) {
    }

    addStudent$(student: StudentInputModel) {
      return this.http.post(`${this.url}/${this.endpoint}`, student).pipe(tap(console.log));
    }
}
