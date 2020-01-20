import {Component, OnInit, ViewChild} from '@angular/core';
import {MatTableDataSource} from "@angular/material/table";
import {select, Store} from "@ngrx/store";
import {AppState} from "../../state/app.state";
import {NbDialogService} from "@nebular/theme";
import {SchoolAdminService} from "../shared/services/school-admin.service";
import {map} from "rxjs/operators";
import {selectSchoolId} from "../../auth/state/auth.reducer";
import {ClassViewModel} from "../shared/models/class-view.model";
import {MinimalSchoolUser} from "../../shared/models/minimal-school-user.interface";
import {MatSort} from "@angular/material/sort";

@Component({
  selector: 'app-classes-list',
  templateUrl: './classes-list.component.html',
  styleUrls: ['./classes-list.component.scss']
})
export class ClassesListComponent implements OnInit {
  dataForTable: MatTableDataSource<ClassViewModel>;
  classesColumns: string[] = ['grade', 'startYear', 'classTeacher', 'actions'];
  schoolId: string;

  @ViewChild(MatSort, {static: true}) sort: MatSort;
  
  constructor(
      private schoolAdminService: SchoolAdminService,
      store: Store<AppState>,
      private dialogService: NbDialogService
  ) {
    store.pipe(select(selectSchoolId)).subscribe(
        (schoolId: string) => this.schoolId = schoolId
    );
  }

  ngOnInit() {
    this.schoolAdminService.getAllClassesInSchool$(this.schoolId).pipe(
        map((classes: ClassViewModel[]) => { 
          this.dataForTable = new MatTableDataSource<ClassViewModel>(classes);
          this.dataForTable.sort = this.sort;
        })
    ).subscribe();
  }
  
  public getTeacherFullName(teacher: MinimalSchoolUser) {
    return teacher.firstName + " " + teacher.secondName + " " + teacher.lastName;
  }

  public getFullGrade(classModel: ClassViewModel) {
    return classModel.grade + classModel.gradeLetter.toUpperCase();
  }

}
