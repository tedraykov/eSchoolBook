import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {take, tap} from "rxjs/operators";
import {Router} from "@angular/router";
import {SchoolUserInputModel} from "../../models/school-user.model";
import {ParentInputModel} from "../models/parent-input.model";
import {Observable} from "rxjs";
import {StudentService} from "../../../shared/services/student.service";
import {MinimalStudent} from "../../../shared/models/minimal-student.model";
import { CreateUserService } from '../create-user.service';

@Component({
    selector: 'create-parent',
    templateUrl: './create-parent.component.html',
    styleUrls: ['./create-parent.component.scss']
})
export class CreateParentComponent implements OnInit {
    @Input() user: SchoolUserInputModel;
    @Output() back: EventEmitter<void> = new EventEmitter<void>();
    children: MinimalStudent[] = [];
    students: Observable<MinimalStudent[]>;

    constructor(
        private createUserService: CreateUserService,
        private studentService: StudentService,
        private router: Router) {
    }

    ngOnInit() {
        this.students = this.studentService.getAllStudentsBySchool$(this.user.schoolId);
    }

    submitParent() {
        const childrenId: string[] = this.children.map(ch => ch.schoolUserId);
        let parent = <ParentInputModel>{
            ...this.user,
            childrenId
        };
        this.createUserService.addParent$(parent).pipe(
            take(1),
            tap(() => this.router.navigateByUrl('app/admin'))
        ).subscribe();
    }

    addStudentToChildren(student: MinimalStudent) {
        if (!this.children.find(ch => ch.schoolUserId === student.schoolUserId)) {
            this.children.push(student);
        }
    }

    removeChild(student: MinimalStudent) {
        this.children = this.children.filter(ch => ch.schoolUserId !== student.schoolUserId);
    }
}
