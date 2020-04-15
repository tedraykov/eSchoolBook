import {ChangeDetectionStrategy, Component, Input, OnInit} from '@angular/core';

@Component({
  selector: 'app-average-score',
  templateUrl: './average-score.component.html',
  styleUrls: ['./average-score.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AverageScoreComponent implements OnInit {
  @Input() score: number;
  constructor() { }

  ngOnInit() {
  }

  get background() {
    if (this.score < 3.50)
      return "danger";
    if (this.score < 4.50)
      return "warning";
    if (this.score < 5.50)
      return "info";
    if (this.score <= 6)
      return "success";
  }
}
