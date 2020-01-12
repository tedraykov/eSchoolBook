import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {School} from "../models/school.interface";
import {tap} from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class SchoolService {
  readonly url = 'http://localhost:5000';
  private readonly endpoint = '/school';
  constructor(private http: HttpClient) { }

  getAllSchools$(): Observable<School[]> {
    return this.http.get<School[]>(this.url + this.endpoint).pipe(
        tap(console.log)
    );
  }
}
