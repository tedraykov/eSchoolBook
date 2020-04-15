import {Component, OnInit} from '@angular/core';
import {Observable} from "rxjs";
import {NbDialogRef} from "@nebular/theme";
import {TeacherDialogData} from "../../shared/models/TeacherDialogData";

@Component({
  selector: 'app-teacher-dialog',
  templateUrl: './teacher-dialog.component.html',
  styleUrls: ['../../students-data/student-dialog/student-dialog.component.scss']
})
export class TeacherDialogComponent implements OnInit {
  data: Observable<TeacherDialogData>;
  teacher: TeacherDialogData;
  
  constructor(
      protected dialogRef: NbDialogRef<TeacherDialogComponent>
  ) { }

  ngOnInit() {
    this.data.subscribe(
        (teacher: TeacherDialogData) => {
          this.teacher = teacher;
          this.teacher.subjects.sort( s => s.grade);
        }
    );
  }

  close() {
    this.dialogRef.close();
  }

}
