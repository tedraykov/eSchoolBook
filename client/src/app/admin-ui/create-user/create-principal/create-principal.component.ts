import {Component, Input, OnInit} from '@angular/core';
import {take, tap} from "rxjs/operators";
import {PrincipalService} from "../../../shared/services/principal.service";
import {Router} from "@angular/router";
import {SchoolUserInputModel} from "../../models/school-user.model";

@Component({
    selector: 'create-principal',
    templateUrl: './create-principal.component.html',
    styleUrls: ['./create-principal.component.scss']
})
export class CreatePrincipalComponent implements OnInit {
    @Input() user: SchoolUserInputModel;

    constructor(
        private principalService: PrincipalService,
        private router: Router) {
    }

    ngOnInit() {
    }

    submitPrincipal() {
        this.principalService.addPrincipal$(this.user).pipe(
            take(1),
            tap(() => this.router.navigateByUrl('app/admin'))
        ).subscribe();
    }
}
