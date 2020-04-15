import {NbDialogRef} from "@nebular/theme";
import {Component, OnInit} from '@angular/core';
import {StudentDialogData} from "../../shared/models/StudentDialogData";
import {Observable} from "rxjs";

@Component({
  selector: 'app-student-dialog',
  templateUrl: './student-dialog.component.html',
  styleUrls: ['./student-dialog.component.scss']
})
export class StudentDialogComponent implements OnInit {
  data: Observable<StudentDialogData>;
  student: StudentDialogData;
  
  constructor(
      protected dialogRef: NbDialogRef<StudentDialogComponent>
  ) { }

  ngOnInit() {
    this.data.subscribe(
        (student: StudentDialogData) => this.student = student
    );
  }

  close() {
    this.dialogRef.close();
  }
}
