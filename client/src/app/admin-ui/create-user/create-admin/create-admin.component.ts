import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {Router} from "@angular/router";
import {take, tap} from "rxjs/operators";

import {SchoolUserInputModel} from "../../models/school-user.model";
import { CreateUserService } from '../create-user.service';

@Component({
    selector: 'create-admin',
    templateUrl: './create-admin.component.html',
    styleUrls: ['./create-admin.component.scss']
})
export class CreateAdminComponent implements OnInit {
    @Input() user: SchoolUserInputModel;
    @Output() back: EventEmitter<void> = new EventEmitter<void>();

    constructor(
        private createUserService: CreateUserService,
        private router: Router
    ) {
    }

    ngOnInit() {
    }

    submitAdmin() {
        this.createUserService.addAdmin$(this.user).pipe(
            take(1),
            tap(() => this.router.navigateByUrl('app/admin'))
        ).subscribe();
    }
}
