import { Component, OnInit } from '@angular/core';
import { TeacherService } from "../shared/services/teacher.service";
import { Observable } from "rxjs";
import { Subject } from "../shared/models/subject";
import { MatTableDataSource } from "@angular/material/table";
import { map } from "rxjs/operators";

@Component({
   selector: 'app-subject-list',
   templateUrl: './subject-list.html',
   styleUrls: ['./subject-list.scss']
})
export class SubjectListComponent implements OnInit {
   dataForTable: Observable<MatTableDataSource<Subject>>;
   subjectColumns: string[] = ['name', 'grade', 'weekday', 'time', 'actions'];

   constructor(private teacherService: TeacherService) {
   }

   ngOnInit() {
      const teacherId = 'mocked teacher id';
      this.dataForTable = this.teacherService.getSubjectsFromCurriculum$(teacherId).pipe(
            map((subjects: Subject[]) => new MatTableDataSource<Subject>(subjects))
      );
   }
}
