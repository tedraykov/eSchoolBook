import {Component, OnInit} from '@angular/core';
import {AppState} from "../../state/app.state";
import {select, Store} from "@ngrx/store";
import {selectSchoolId} from "../../auth/state/auth.reducer";
import {StatisticsService} from "../../shared/services/statistics.service";
import {Observable} from "rxjs";
import {StringDoubleModel} from "../../shared/models/string-double.model";

@Component({
   selector: 'app-statistics',
   templateUrl: './principal-statistics.component.html',
   styleUrls: ['./principal-statistics.component.scss']
})
export class PrincipalStatisticsComponent implements OnInit {
   avgScore: Observable<number>;
   absences: Observable<Array<StringDoubleModel>>;
   schoolId: string;
   subjectsAvg: Observable<Array<StringDoubleModel>>;
   teachersAvg: Observable<Array<StringDoubleModel>>;
   
   constructor(
       private statisticsService: StatisticsService,
       store: Store<AppState>
   ) {
      store.pipe(select(selectSchoolId)).subscribe(
          (schoolId: string) => this.schoolId = schoolId
      )
   }

   ngOnInit() {
      this.avgScore = this.statisticsService.getSchoolAverageScore$(this.schoolId);
      this.absences = this.statisticsService.getSchoolAbsences$(this.schoolId);
      this.subjectsAvg = this.statisticsService.getSchoolSubjectsAverageScore$(this.schoolId);
      this.teachersAvg = this.statisticsService.getSchoolTeachersAverageScore$(this.schoolId);
   }

}
