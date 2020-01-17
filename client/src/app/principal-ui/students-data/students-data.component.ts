import {Component, OnInit} from '@angular/core';
import {Observable} from "rxjs";
import {MatTableDataSource} from "@angular/material/table";
import {PrincipalService} from "../shared/services/principal.service";
import {AppState} from "../../state/app.state";
import {select, Store} from '@ngrx/store'
import {map, tap} from "rxjs/operators";
import {NbDialogService} from "@nebular/theme";
import {SchoolUsersTableData} from "../shared/models/SchoolUsersTableData";
import {StudentDialogData} from "../shared/models/StudentDialogData";
import {selectSchoolId} from "../../auth/state/auth.reducer";
import {StudentDialogComponent} from "./student-dialog/student-dialog.component";

@Component({
   selector: 'app-students-data',
   templateUrl: './students-data.component.html',
   styleUrls: ['./students-data.component.scss']
})
export class StudentsDataComponent implements OnInit {
   dataForTable: Observable<MatTableDataSource<SchoolUsersTableData>>;
   studentColumns: string[] = ['name', 'address', 'grade', 'actions'];
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
      this.dataForTable = this.principalService.getStudentsData$(this.schoolId).pipe(
          map((students: SchoolUsersTableData[]) => new MatTableDataSource<SchoolUsersTableData>(students))
      );
   }
   
   public openDialog(studentData: SchoolUsersTableData){
      this.dialogService.open(StudentDialogComponent, {
         context: {
            data: this.principalService.getStudentData$(studentData.schoolUserId)
         }
      });
   }

}