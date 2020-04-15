import {Component, Input, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {SubjectViewModel} from "../shared/models/subject-view.model";
import {SchoolAdminService} from "../shared/services/school-admin.service";
import {ConfirmationDialogComponent} from "../../shared/components/dialogs/confirmation-dialog/confirmation-dialog.component";
import {NbDialogService} from "@nebular/theme";
import {map, take} from "rxjs/operators";
import {SubjectInputModel} from "../shared/models/subject-input.model";

@Component({
    selector: 'app-add-subject',
    templateUrl: './add-subject.component.html',
    styleUrls: ['./add-subject.component.scss']
})
export class AddSubjectComponent implements OnInit {
    @Input() subject: SubjectViewModel;
    @Input() type: string = 'edit';
    
    subjectForm = new FormGroup({
        name: new FormControl('',
            [Validators.required]),
        grade: new FormControl('',
            [Validators.required, Validators.min(1), Validators.max(12)]),
    });

    constructor(
        private schoolAdminService: SchoolAdminService,
        private dialogService: NbDialogService
    ) {
    }

    ngOnInit() {
    }

    public addSubject() {
        const subject = this.subjectForm.value as SubjectInputModel;
        subject.gradeYear = this.subjectForm.value.grade;
        // console.log(subject, this.subjectForm.value);
        let approved = false;

        this.showConfirmationDialog(`Сигурни ли сте, че искате да добавите "${subject.name}" 
        в предметите на ${subject.gradeYear} клас?`)
            .pipe(take(1), map(x => approved = x))
            .subscribe(() => {
                if (approved) this.schoolAdminService.addSubject$(subject).subscribe();
                this.subjectForm.reset();
            });

    }

    public editSubject() {
        const subject = this.subjectForm.value as SubjectInputModel;
        subject.gradeYear = this.subjectForm.value.grade;
        let approved = false;
        
        this.showConfirmationDialog("Сигурни ли сте, че искате да редактирате този предмет?")
            .pipe(take(1), map(x => approved = x))
            .subscribe(() => {
                if (approved) this.schoolAdminService.editSubject$(this.subject.id, subject).subscribe();
                this.subjectForm.reset();
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
        const formControl = this.subjectForm.get(formControlName);
        if (formControl.valid) {
            return 'success';
        }
        if (formControl.touched && !formControl.valid) {
            return 'danger'
        }
        return 'basic';
    }

}
