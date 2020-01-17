import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {take, tap} from "rxjs/operators";
import {Router} from "@angular/router";
import {SchoolUserInputModel} from "../../models/school-user.model";
import { CreateUserService } from '../create-user.service';

@Component({
    selector: 'create-principal',
    templateUrl: './create-principal.component.html',
    styleUrls: ['./create-principal.component.scss']
})
export class CreatePrincipalComponent implements OnInit {
    @Input() user: SchoolUserInputModel;
    @Output() back: EventEmitter<void> = new EventEmitter<void>();

    constructor(
        private createUserService: CreateUserService,
        private router: Router) {
    }

    ngOnInit() {
    }

    submitPrincipal() {
        this.createUserService.addPrincipal$(this.user).pipe(
            take(1),
            tap(() => this.router.navigateByUrl('app/admin'))
        ).subscribe();
    }
}
