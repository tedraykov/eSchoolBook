import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class PrincipalService {
   private readonly serverUrl = "http://localhost:5000";

   constructor(private http: HttpClient) {
   }
}
