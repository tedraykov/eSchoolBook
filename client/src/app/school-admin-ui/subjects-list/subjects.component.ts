import {Component, OnInit} from '@angular/core';
import {SubjectViewModel} from "../shared/models/subject-view.model";
import {SchoolAdminService} from "../shared/services/school-admin.service";
import {map, take} from "rxjs/operators";
import {from, Observable} from "rxjs";
import {TeacherDialogComponent} from "../../principal-ui/teachers-data/teacher-dialog/teacher-dialog.component";
import {NbDialogRef, NbDialogService} from "@nebular/theme";
import {ConfirmationDialogComponent} from "../../shared/components/dialogs/confirmation-dialog/confirmation-dialog.component";

@Component({
    selector: 'app-subjects',
    templateUrl: './subjects.component.html',
    styleUrls: ['./subjects.component.scss']
})
export class SubjectsComponent implements OnInit {
    data: Array<SubjectViewModel> = [];
    detailed: SubjectViewModel;
    grades: number[] = Array.from({length: 13}, (v, i) => i);
    grade: number = this.grades[1];
    subjectEditMode: boolean = false;
    
    constructor(
        private schoolAdminService: SchoolAdminService,
        private dialogService: NbDialogService
    ) {
    }

    ngOnInit() {
        this.grades.shift();
        this.getSubjectsByGrade(this.grade);
    }

    protected getSubjectsByGrade(grade: number): void {
        this.schoolAdminService.getAllSubjectsByGrade$(grade)
            .pipe(take(1))
            .subscribe((subjects: SubjectViewModel[]) => {
                this.data = subjects;
                this.showDetails(subjects[0].id);
            });
    }

    protected showDetails(subjectId: string): void {
        this.schoolAdminService.getSubjectDetails$(subjectId)
            .pipe(take(1))
            .subscribe((subject: SubjectViewModel) => {
                this.detailed = subject;
            })
    }

    protected showConfirmationDialog(message: string) {
        const dialog = this.dialogService.open(ConfirmationDialogComponent, {
            context: {
                message: message
            }
        });

        return dialog.onClose;
    }

    public deleteSubject(subjectId: string): void {
        let approved = false;

        this.showConfirmationDialog("Операцията е необратима, сигурни ли сте, че искате да продължите?")
            .pipe(take(1), map(x => {
                approved = x;
            }))
            .subscribe(() => {
                if (approved) this.schoolAdminService.deleteSubject$(subjectId)
                    .subscribe(() => this.getSubjectsByGrade(this.grade));
            });
    }

    public editSubject(): void {
        this.subjectEditMode = true;
    }

}
