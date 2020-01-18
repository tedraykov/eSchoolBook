import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {FormBuilder, Validators} from "@angular/forms";
import {ClassService} from "../../../shared/services/class.service";
import {Observable} from "rxjs";
import {Class} from "../../../shared/models/class.interface";
import {StudentFormInputModel} from "../models/student-form-input.model";
import {SchoolUserInputModel} from "../../models/school-user.model";
import {StudentInputModel} from "../models/student-input.model";
import {StudentService} from "../../../shared/services/student.service";
import {Router} from "@angular/router";
import {take, tap} from "rxjs/operators";

@Component({
    selector: 'create-student',
    templateUrl: './create-student.component.html',
    styleUrls: ['./create-student.component.scss']
})
export class CreateStudentComponent implements OnInit {
    @Input() user: SchoolUserInputModel;
    @Output() back: EventEmitter<void> = new EventEmitter<void>();
    studentForm = this.fb.group({
        class: ['', Validators.required],
        startYear: [`${new Date().getFullYear()}`, [Validators.min(1970), Validators.required]]
    });
    classes: Observable<Class[]>;

    constructor(
        private fb: FormBuilder,
        private classService: ClassService,
        private studentService: StudentService,
        private router: Router) {
    }

    ngOnInit() {
        this.classes = this.classService.getAllClasses$(this.user.schoolId);
    }

    submitStudent() {
        const studentFromData = this.studentForm.value as StudentFormInputModel;
        const student = <StudentInputModel>{
            ...this.user,
            classId: studentFromData.class.id,
            startYear: studentFromData.startYear
        };
        this.studentService.addStudent$(student).pipe(
            take(1),
            tap(() => this.router.navigateByUrl('app/admin'))
        ).subscribe();
    }
}
