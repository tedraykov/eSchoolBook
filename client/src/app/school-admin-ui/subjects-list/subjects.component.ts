import {Component, OnInit} from '@angular/core';
import {SubjectViewModel} from "../shared/models/subject-view.model";
import {SchoolAdminService} from "../shared/services/school-admin.service";
import {map, take} from "rxjs/operators";
import {NbDialogService} from "@nebular/theme";
import {ConfirmationDialogComponent} from "../../shared/components/dialogs/confirmation-dialog/confirmation-dialog.component";
import {select, Store} from "@ngrx/store";
import {selectSchoolId} from "../../auth/state/auth.reducer";
import {AppState} from "../../state/app.state";
import {ConfigureSubjectTeacherComponent} from "../configure-subject-teacher/configure-subject-teacher.component";

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
    schoolId: string;
    
    constructor(
        private schoolAdminService: SchoolAdminService,
        private dialogService: NbDialogService,
        store: Store<AppState>
    ) {
        store.pipe(select(selectSchoolId)).subscribe(
            (schoolId: string) => this.schoolId = schoolId
        )
    }

    ngOnInit() {
        this.grades.shift();
        this.getSubjectsByGrade(this.grade);
    }

    public getSubjectsByGrade(grade: number): void {
        this.schoolAdminService.getAllSubjectsByGrade$(grade)
            .pipe(take(1))
            .subscribe((subjects: SubjectViewModel[]) => {
                this.data = subjects;
                this.showDetails(subjects[0].id);
            });
    }

    public showDetails(subjectId: string): void {
        this.schoolAdminService.getSubjectDetails$(subjectId)
            .pipe(take(1))
            .subscribe((subject: SubjectViewModel) => {
                this.detailed = subject;
            })
    }

    public showConfirmationDialog(message: string) {
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

    public addTeacher(subject: SubjectViewModel){
        let dialogData;

        this.addTeacherDialog(subject).pipe(take(1),
            map(x => dialogData = x))
            .subscribe(() => {
                if (dialogData.approved) this.schoolAdminService.addTeacherToSubject$(subject.id, dialogData.teacherId)
                    .subscribe(() => this.showDetails(subject.id))
            });
    }

    public removeTeacher(subject: SubjectViewModel){
        let dialogData;

        this.removeTeacherDialog(subject).pipe(take(1),
            map(x => dialogData = x))
            .subscribe(() => {
                if (dialogData.approved) this.schoolAdminService.removeTeacherFromSubject$(subject.id, dialogData.teacherId)
                    .subscribe(() => this.showDetails(subject.id))
            });
    }

    protected addTeacherDialog(subject: SubjectViewModel){
        const dialog = this.dialogService.open(ConfigureSubjectTeacherComponent, {
            context: {
                header: "Добави учител",
                agree: "Добави нов преподавател",
                data: this.schoolAdminService.getAllTeachers$(this.schoolId),
                subject: subject
            }
        });
        
        return dialog.onClose;
    }
    
    protected removeTeacherDialog(subject: SubjectViewModel){
        const dialog = this.dialogService.open(ConfigureSubjectTeacherComponent, {
            context: {
                header: "Премахни от списъка с учители",
                agree: "Премахни учител",
                data: this.schoolAdminService.getAllTeachersForSubject$(subject.id),
                subject: subject
            }
        });

        return dialog.onClose;
    }
}
