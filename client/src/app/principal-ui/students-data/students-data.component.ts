import { Component, OnInit } from '@angular/core';
import {Observable, Subscription} from "rxjs";
import {MatTableDataSource} from "@angular/material/table";
import {StudentData} from "../shared/models/StudentData";
import {PrincipalService} from "../shared/services/principal.service";
import {AppState} from "../../state/app.state";
import { select, Store } from '@ngrx/store'
import {selectSchoolId} from "../../auth/state";
import {map} from "rxjs/operators";
import {Subject} from "../../teacher-ui/shared/models/subject";

@Component({
   selector: 'app-students-data',
   templateUrl: './students-data.component.html',
   styleUrls: ['./students-data.component.scss']
})
export class StudentsDataComponent implements OnInit {
   dataForTable: Observable<MatTableDataSource<StudentData>>;
   studentColumns: string[] = ['name', 'address', 'grade', 'actions'];
   schoolId: string;

   constructor(
       private principalService: PrincipalService,
       store: Store<AppState>
   ) {
      store.pipe(select(selectSchoolId)).subscribe(
          (schoolId: string) => this.schoolId = schoolId
      )
   }

   ngOnInit() {
      this.dataForTable = this.principalService.getStudentsData$(this.schoolId).pipe(
          map((students: StudentData[]) => new MatTableDataSource<StudentData>(students))
      );
   }

}