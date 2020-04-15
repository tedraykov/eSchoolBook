import {Component, OnInit} from '@angular/core';
import {MinimalSchoolUser} from "../../shared/models/minimal-school-user.interface";
import {SubjectViewModel} from "../shared/models/subject-view.model";
import {NbDialogRef} from "@nebular/theme";
import {Observable} from "rxjs";

@Component({
    selector: 'app-subject-teacher',
    templateUrl: './configure-subject-teacher.component.html',
    styleUrls: ['./configure-subject-teacher.component.scss']
})
export class ConfigureSubjectTeacherComponent implements OnInit {
    data: Observable<Array<MinimalSchoolUser>>;
    teachers: Array<MinimalSchoolUser>;
    subject: SubjectViewModel;
    header: string;
    selected: string;
    agree: string;

    constructor(
        protected dialogRef: NbDialogRef<ConfigureSubjectTeacherComponent>
    ) {
    }

    ngOnInit() {
        this.data.subscribe(
            (teachers: MinimalSchoolUser[]) => this.teachers = teachers
        );
    }
    
    close() {
        this.dialogRef.close({approved: false});
    }

    public approve(teacherId: string): void {
      this.dialogRef.close({
          approved: true, 
          subjectId: this.subject.id,
          teacherId: teacherId
      });
    }

    public getFullName(teacher: MinimalSchoolUser): string {
        return teacher.firstName + " " + teacher.secondName + " " + teacher.lastName;
    }
}
