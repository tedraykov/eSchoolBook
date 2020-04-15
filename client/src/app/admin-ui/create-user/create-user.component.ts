import {Component, OnInit, ViewChild} from '@angular/core';
import {SchoolService} from "../../shared/services/school.service";
import {Observable} from "rxjs";
import {School} from "../../shared/models/school.interface";
import {Roles} from "../../shared/enums/school-user-roles";
import {FormBuilder, Validators} from "@angular/forms";
import {SchoolUserInputModel} from "../models/school-user.model";
import {StudentFormInputModel} from "./models/student-form-input.model";
import {StudentInputModel} from "./models/student-input.model";
import {tap} from "rxjs/operators";
import {NbStepperComponent} from "@nebular/theme";
import {select, Store} from "@ngrx/store";
import {AppState} from "../../state/app.state";
import {selectRole, selectSchoolId} from "../../auth/state/auth.reducer";

@Component({
    selector: 'app-create-user',
    templateUrl: './create-user.component.html',
    styleUrls: ['./create-user.component.scss']
})
export class CreateUserComponent implements OnInit {
    schools: Observable<School[]>;
    roles: string[] = [];
    baseUserComplete: boolean = false;
    studentData: StudentFormInputModel;
    @ViewChild('userStepper', {static: false}) stepper: NbStepperComponent;
    currentRole: string;

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
        private fb: FormBuilder,
        store: Store<AppState>,) {
        
        store.pipe(select(selectRole)).subscribe(
            (role: string) => this.currentRole = role
        );

        if (this.currentRole === 'Admin') {
            store.pipe(select(selectSchoolId)).subscribe(
                (schoolId: string) => this.createUser.controls['schoolId'].setValue(schoolId)
            );
        }
    }

    ngOnInit() {
        this.schools = this.schoolService.getAllSchools$();
        for (let role in Roles) {
            if (role !== 'SuperAdmin') {
                this.roles.push(role);
            }
        }

        this.createUser.valueChanges.pipe(
            tap(() => this.baseUserComplete = false)
        ).subscribe();
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

    onBack() {
        this.stepper.previous();
    }
}
