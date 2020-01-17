import { Component, OnInit } from '@angular/core';
import {Observable} from "rxjs";
import {StudentDialogData} from "../../shared/models/StudentDialogData";
import {NbDialogRef} from "@nebular/theme";
import {ParentData} from "../../shared/models/ParentData";

@Component({
  selector: 'app-parent-dialog',
  templateUrl: './parent-dialog.component.html',
  styleUrls: ['../../students-data/student-dialog/student-dialog.component.scss']
})
export class ParentDialogComponent implements OnInit {
  data: Observable<ParentData>;
  parent: ParentData;
  
  constructor(
      protected dialogRef: NbDialogRef<ParentDialogComponent>
  ) { }

  ngOnInit() {
    this.data.subscribe(
        (parent: ParentData) => this.parent = parent
    );
  }

  close() {
    this.dialogRef.close();
  }

}
