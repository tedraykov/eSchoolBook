import {Component, Input, OnInit} from '@angular/core';
import {take, tap} from "rxjs/operators";
import {ParentService} from "../../../shared/services/parent.service";
import {Router} from "@angular/router";
import {SchoolUserInputModel} from "../../models/school-user.model";
import {ParentInputModel} from "../models/parent-input.model";
import {Observable} from "rxjs";
import {StudentService} from "../../../shared/services/student.service";
import {MinimalStudent} from "../models/minimal-student.model";

@Component({
    selector: 'create-parent',
    templateUrl: './create-parent.component.html',
    styleUrls: ['./create-parent.component.scss']
})
export class CreateParentComponent implements OnInit {
    @Input() user: SchoolUserInputModel;
    children: MinimalStudent[] = [];
    students: Observable<MinimalStudent[]>;
    constructor(
        private parentService: ParentService,
        private studentService: StudentService,
        private router: Router) {
    }

    ngOnInit() {
      this.students = this.studentService.getAllStudentsBySchool$(this.user.schoolId).pipe(tap(console.log));
    }

    submitParent() {
        const childrenId: string[] = this.children.map(ch => ch.id);
        let parent = <ParentInputModel>{
          ...this.user,
          childrenId
        };

        this.parentService.addParent$(parent).pipe(
            take(1),
            tap(() => this.router.navigateByUrl('app/admin'))
        ).subscribe();
    }

    addStudentToChildren(student: MinimalStudent) {
        if (!this.children.find(ch => ch.id === student.id)) {
            this.children.push(student);
        }
    }

    removeChild(student: MinimalStudent) {
        this.children = this.children.filter(ch => ch.id !== student.id);
    }
}
