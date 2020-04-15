import {Component, OnInit} from '@angular/core';
import {PrincipalService} from "../shared/services/principal.service";
import {Observable} from "rxjs";
import {MatTableDataSource} from "@angular/material/table";
import {select, Store} from "@ngrx/store";
import {AppState} from "../../state/app.state";
import {NbDialogService} from "@nebular/theme";
import {selectSchoolId} from "../../auth/state/auth.reducer";
import {map} from "rxjs/operators";
import {SchoolUsersTableData} from "../shared/models/SchoolUsersTableData";
import {TeacherDialogData} from "../shared/models/TeacherDialogData";
import {StudentDialogComponent} from "../students-data/student-dialog/student-dialog.component";
import {TeacherDialogComponent} from "./teacher-dialog/teacher-dialog.component";

@Component({
   selector: 'app-teachers-data',
   templateUrl: './teachers-data.component.html',
   styleUrls: ['./teachers-data.component.scss']
})
export class TeachersDataComponent implements OnInit {
   dataForTable: Observable<MatTableDataSource<SchoolUsersTableData>>;
   teacherColumns: string[] = ['name', 'address', 'class', 'actions'];
   schoolId: string;
   
   constructor(
       private principalService: PrincipalService,
       store: Store<AppState>,
       private dialogService: NbDialogService
   ) {
      store.pipe(select(selectSchoolId)).subscribe(
          (schoolId: string) => this.schoolId = schoolId
      );
   }

   ngOnInit() {
      this.dataForTable = this.principalService.getTeachersData$(this.schoolId).pipe(
          map((teachers: SchoolUsersTableData[]) => new MatTableDataSource<SchoolUsersTableData>(teachers))
      );
   }

   public openDialog(teacherData: SchoolUsersTableData){
      this.dialogService.open(TeacherDialogComponent, {
         context: {
            data: this.principalService.getTeacherData$(teacherData.schoolUserId)
         }
      });
   }
}