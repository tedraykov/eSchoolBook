import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {Class} from "../../shared/models/class.interface";
import {MinimalSchoolUser} from "../../shared/models/minimal-school-user.interface";
import {SchoolAdminService} from "../shared/services/school-admin.service";
import {select, Store} from "@ngrx/store";
import {AppState} from "../../state/app.state";
import {NbDialogService} from "@nebular/theme";
import {selectSchoolId} from "../../auth/state/auth.reducer";
import {map, take} from "rxjs/operators";
import {ClassInputModel} from "../shared/models/class-input.model";
import {ConfirmationDialogComponent} from "../../shared/components/dialogs/confirmation-dialog/confirmation-dialog.component";

@Component({
    selector: 'app-add-class',
    templateUrl: './add-class.component.html',
    styleUrls: ['./add-class.component.scss']
})
export class AddClassComponent implements OnInit {

    classForm = new FormGroup({
        startYear: new FormControl('', [Validators.required, Validators.maxLength(4)]),
        grade: new FormControl('', [Validators.min(1), Validators.max(12),
            Validators.maxLength(2), Validators.minLength(1)]),
        gradeLetter: new FormControl('', [Validators.required, Validators.maxLength(1)])
    });
    
    classTeacherForm = new FormGroup({
        classId: new FormControl('', [Validators.required]),
        teacherId: new FormControl('', [Validators.required])
    });

    schoolId: string;
    currentYear: number = new Date().getFullYear();
    unassignedClasses: Array<Class>;
    unassignedTeachers: Array<MinimalSchoolUser>;

    selectedClass: Class;
    selectedTeacher: MinimalSchoolUser;

    constructor(
        private schoolAdminService: SchoolAdminService,
        store: Store<AppState>,
        private dialogService: NbDialogService
    ) {
        store.pipe(select(selectSchoolId)).subscribe(
            (schoolId: string) => this.schoolId = schoolId
        );
    }

    ngOnInit() {
        this.schoolAdminService.getAllUnassignedClasses$(this.schoolId)
            .pipe(map((classes: Array<Class>) => {
                this.unassignedClasses = classes;
                this.selectedClass = classes[0];
            })).subscribe();

        this.schoolAdminService.getAllUnassignedTeachers$(this.schoolId)
            .pipe(map((teachers: Array<MinimalSchoolUser>) => {
                this.unassignedTeachers = teachers;
                this.selectedTeacher = teachers[0];
            })).subscribe();
    }

    public addClass() {
        const newClass = this.classForm.value as ClassInputModel;
        newClass.schoolId = this.schoolId;
        let approved = false;

        this.showConfirmationDialog(`Сигурни ли сте, че искате да добавите 
        "${this.getFullGrade(newClass)}" към випуск ${newClass.startYear}?`)
            .pipe(take(1), map(x => approved = x))
            .subscribe(() => {
                if (approved) {
                    this.schoolAdminService.addNewClass$(newClass).subscribe();
                    this.schoolAdminService.getAllUnassignedClasses$(this.schoolId);
                }
                this.classForm.reset();
            });
    }

    public addClassTeacher() {
        let approved = false;
        this.showConfirmationDialog(`Сигурни ли сте, че искате да направите  
          ${this.getTeacherFullName(this.selectedTeacher)} класен ръководител на 
          ${this.getFullGrade(this.selectedClass)}?`)
            .pipe(take(1), map(x => approved = x))
            .subscribe(() => {
                if (approved) 
                  this.schoolAdminService.addClassTeacher$(this.selectedClass.id, this.selectedTeacher.id).subscribe();
                this.classForm.reset();
            });
    }

    protected showConfirmationDialog(message: string) {
        const dialog = this.dialogService.open(ConfirmationDialogComponent, {
            context: {
                message: message
            }
        });

        return dialog.onClose;
    }

    public getInputStatus(formControlName: string) {
        const formControl = this.classForm.get(formControlName);
        if (formControl.valid && formControl.dirty) {
            return 'success';
        }
        if (formControl.touched && !formControl.valid) {
            return 'danger'
        }
        return 'basic';
    }

    public getTeacherFullName(teacher: MinimalSchoolUser) {
        return teacher.firstName + " " + teacher.secondName + " " + teacher.lastName;
    }

    public getFullGrade(classModel: Class | ClassInputModel) {
        return classModel.grade + classModel.gradeLetter.toUpperCase();
    }

}
