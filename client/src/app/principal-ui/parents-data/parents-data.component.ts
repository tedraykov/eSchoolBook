import {Component, OnInit} from '@angular/core';
import {Observable} from "rxjs";
import {MatTableDataSource} from "@angular/material/table";
import {PrincipalService} from "../shared/services/principal.service";
import {select, Store} from "@ngrx/store";
import {AppState} from "../../state/app.state";
import {NbDialogService} from "@nebular/theme";
import {map} from "rxjs/operators";
import {selectSchoolId} from "../../auth/state/auth.reducer";
import {ParentDialogComponent} from "./parent-dialog/parent-dialog.component";
import {ParentData} from "../shared/models/ParentData";

@Component({
   selector: 'app-parents-data',
   templateUrl: './parents-data.component.html',
   styleUrls: ['./parents-data.component.scss']
})
export class ParentsDataComponent implements OnInit {
   dataForTable: Observable<MatTableDataSource<ParentData>>;
   parentColumns: string[] = ['name', 'address', 'children', 'actions'];
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
          map((parents: ParentData[]) => new MatTableDataSource<ParentData>(parents))
      );
   }

   public openDialog(parentData: ParentData){
      this.dialogService.open(ParentDialogComponent, {
         context: {
            data: this.principalService.getParentData$(parentData.schoolUserId)
         }
      });
   }

}