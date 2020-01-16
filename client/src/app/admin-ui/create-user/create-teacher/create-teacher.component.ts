import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {TeacherService} from "../../../shared/services/teacher.service";
import {SchoolUserInputModel} from "../../models/school-user.model";
import {take, tap} from "rxjs/operators";
import {Router} from "@angular/router";

@Component({
    selector: 'create-teacher',
    templateUrl: './create-teacher.component.html',
    styleUrls: ['./create-teacher.component.scss']
})
export class CreateTeacherComponent implements OnInit {
    @Input() user: SchoolUserInputModel;
    @Output() back: EventEmitter<void> = new EventEmitter<void>();
    constructor(
        private teacherService: TeacherService,
        private router: Router) {
    }

    ngOnInit() {
    }

    submitTeacher() {
        this.teacherService.addTeacher$(this.user).pipe(
            take(1),
            tap(() => this.router.navigateByUrl('app/admin'))
        ).subscribe();
    }
}
