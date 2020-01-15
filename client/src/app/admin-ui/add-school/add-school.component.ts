import {Component, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {SchoolService} from "../../shared/services/school.service";
import {SchoolInputModel} from "./models/school-input.model";
import {take, tap} from "rxjs/operators";
import {Router} from "@angular/router";

@Component({
    selector: 'app-add-school',
    templateUrl: './add-school.component.html',
    styleUrls: ['./add-school.component.scss']
})
export class AddSchoolComponent implements OnInit {
    schoolForm = new FormGroup({
        name: new FormControl('', [Validators.required]),
        number: new FormControl('', [Validators.min(1), Validators.max(999)]),
        address: new FormControl('', [Validators.required])
    });

    constructor(
        private schoolService: SchoolService,
        private router: Router) {
    }

    ngOnInit() {
    }

    addSchool() {
      const school = this.schoolForm.value as SchoolInputModel;
      this.schoolService.addSchool$(school).pipe(
          take(1),
          tap(() => this.router.navigateByUrl('app/admin'))
      ).subscribe();
    }

    getInputStatus(formControlName: string) {
        const formControl = this.schoolForm.get(formControlName);
        if (formControl.valid && formControl.dirty) {
          return 'success';
        }
        if (formControl.touched && !formControl.valid) {
          return 'danger'
        }
      return 'basic';
    }

}
