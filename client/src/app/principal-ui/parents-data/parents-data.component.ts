import { Component, OnInit } from '@angular/core';
import {Observable} from "rxjs";
import {MatTableDataSource} from "@angular/material/table";
import {SchoolUsersTableData} from "../shared/models/SchoolUsersTableData";
import {TeacherDialogData} from "../shared/models/TeacherDialogData";
import {ParentTableData} from "../shared/models/ParentTableData";
import {ParentDialogData} from "../shared/models/ParentDialogData";
import {PrincipalService} from "../shared/services/principal.service";
import {select, Store} from "@ngrx/store";
import {AppState} from "../../state/app.state";
import {NbDialogService} from "@nebular/theme";
import {map} from "rxjs/operators";
import {selectSchoolId} from "../../auth/state/auth.reducer";

@Component({
   selector: 'app-parents-data',
   templateUrl: './parents-data.component.html',
   styleUrls: ['./parents-data.component.scss']
})
export class ParentsDataComponent implements OnInit {
   dataForTable: Observable<MatTableDataSource<ParentTableData>>;
   parentColumns: string[] = ['name', 'address', 'children', 'actions'];
   dataForDialog: Observable<ParentDialogData>;
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
      this.dataForTable = this.principalService.getParentsData$(this.schoolId).pipe(
          map((parents: ParentTableData[]) => new MatTableDataSource<ParentTableData>(parents))
      );
   }

}