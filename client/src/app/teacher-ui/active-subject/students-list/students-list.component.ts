import { Component, OnInit } from '@angular/core';
import { StudentInSubject } from "../../shared/models/student-in-subject.model";
import { mockedStudentsInSubject } from "../../shared/services/mocked-students";
import { MatTableDataSource } from "@angular/material/table";

@Component({
   selector: 'students-list',
   templateUrl: './students-list.html',
   styleUrls: ['./students-list.scss']
})
export class StudentsListComponent implements OnInit {
   studentColumns: string[] = ['fullName', 'grades', 'absences', 'actions'];
   dataForTable: MatTableDataSource<StudentInSubject>;

   constructor() {
   }

   ngOnInit() {
      this.dataForTable = new MatTableDataSource<StudentInSubject>(mockedStudentsInSubject);
   }

}
