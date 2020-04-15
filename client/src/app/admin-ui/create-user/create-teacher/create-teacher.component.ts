import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {SchoolUserInputModel} from "../../models/school-user.model";
import {take, tap} from "rxjs/operators";
import {Router} from "@angular/router";
import { CreateUserService } from '../create-user.service';

@Component({
    selector: 'create-teacher',
    templateUrl: './create-teacher.component.html',
    styleUrls: ['./create-teacher.component.scss']
})
export class CreateTeacherComponent implements OnInit {
    @Input() user: SchoolUserInputModel;
    @Output() back: EventEmitter<void> = new EventEmitter<void>();
    constructor(
        private createUserService: CreateUserService,
        private router: Router) {
    }

    ngOnInit() {
    }

    submitTeacher() {
        this.createUserService.addTeacher$(this.user).pipe(
            take(1),
            tap(() => this.router.navigateByUrl('app/admin'))
        ).subscribe();
    }
}
