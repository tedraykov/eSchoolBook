import {Component, OnInit} from '@angular/core';
import {SchoolService} from "../../shared/services/school.service";
import {Observable} from "rxjs";
import {School} from "../../shared/models/school.interface";
import {Roles} from "../../shared/enums/school-user-roles";
import {FormBuilder, Validators} from "@angular/forms";
import {SchoolUserInputModel} from "../models/school-user.model";
import {StudentFormInputModel} from "./models/student-form-input.model";
import {StudentInputModel} from "./models/student-input.model";

@Component({
    selector: 'app-create-user',
    templateUrl: './create-user.html',
    styleUrls: ['./create-user.scss']
})
export class CreateUserComponent implements OnInit {
    schools: Observable<School[]>;
    roles: string[] = [];
    baseUserComplete: boolean = false;
    studentData: StudentFormInputModel;

    createUser = this.fb.group({
        firstName: ['Tedi', Validators.required],
        secondName: ['Radoslavov'],
        lastName: ['Raykov', Validators.required],
        pin: ['9810047166', Validators.required],
        address: ['Obelya, ul. 4-ta 4a', Validators.required],
        town: ['Sofia', Validators.required],
        schoolId: ['', Validators.required],
        role: ['Student', Validators.required]
    });

    constructor(
        private schoolService: SchoolService,
        private fb: FormBuilder) {
    }

    ngOnInit() {
        this.schools = this.schoolService.getAllSchools$();
        for (let role in Roles) {
            if (role !== 'SuperAdmin') {
                this.roles.push(role);
            }
        }
    }

    getRole() {
        return (this.createUser.value as SchoolUserInputModel).role;
    }

    completeBaseUser() {
        this.baseUserComplete = true;
    }

    getUserData(): SchoolUserInputModel {
        return this.createUser.value as SchoolUserInputModel;
    }
}
