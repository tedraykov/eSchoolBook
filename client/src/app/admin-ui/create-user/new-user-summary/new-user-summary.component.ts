import {Component, Input, OnInit} from '@angular/core';
import {SchoolUserInputModel} from "../../models/school-user.model";

@Component({
  selector: 'new-user-summary',
  templateUrl: './new-user-summary.component.html',
  styleUrls: ['./new-user-summary.component.scss']
})
export class NewUserSummaryComponent implements OnInit {
  @Input() schoolUser: SchoolUserInputModel;
  constructor() { }

  ngOnInit() {
  }
  getFullName(): string {
    let fullName = this.schoolUser.firstName;
    if(this.schoolUser.secondName) {
      fullName += ' ' + this.schoolUser.secondName;
    }
    fullName += ' ' + this.schoolUser.lastName;
    return fullName;
  }
}
