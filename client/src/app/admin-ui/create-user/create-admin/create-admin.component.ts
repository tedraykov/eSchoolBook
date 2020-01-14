import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {SchoolAdminService} from "../../../shared/services/school-admin.service";
import {Router} from "@angular/router";
import {SchoolUserInputModel} from "../../models/school-user.model";
import {take, tap} from "rxjs/operators";

@Component({
    selector: 'create-admin',
    templateUrl: './create-admin.component.html',
    styleUrls: ['./create-admin.component.scss']
})
export class CreateAdminComponent implements OnInit {
    @Input() user: SchoolUserInputModel;
    @Output() back: EventEmitter<void> = new EventEmitter<void>();

    constructor(
        private schoolAdminService: SchoolAdminService,
        private router: Router
    ) {
    }

    ngOnInit() {
    }

    submitAdmin() {
        this.schoolAdminService.addSchoolAdmin$(this.user).pipe(
            take(1),
            tap(() => this.router.navigateByUrl('app/admin'))
        ).subscribe();
    }
}
