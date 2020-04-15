import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {ParentInputModel} from "../../admin-ui/create-user/models/parent-input.model";
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ParentService {
  private readonly serverUrl = environment.serverUrl;
  private readonly parentEndpoint = "parent";

  constructor(private http: HttpClient) {
  }

  addParent$(parent: ParentInputModel) {
    return this.http.post(`${this.serverUrl}/${this.parentEndpoint}`, parent);
  }
}
