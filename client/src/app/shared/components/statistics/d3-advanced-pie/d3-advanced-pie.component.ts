import {Component, Input, OnInit} from '@angular/core';
import {NbThemeService} from "@nebular/theme";
import {take} from "rxjs/operators";
import {StringDoubleModel} from "../../../models/string-double.model";

@Component({
  selector: 'app-d3-advanced-pie',
  templateUrl: './d3-advanced-pie.component.html',
  styleUrls: ['./d3-advanced-pie.component.scss']
})
export class D3AdvancedPieComponent implements OnInit {
  colorScheme: any;
  @Input() result: Array<StringDoubleModel>;

  constructor(
      private theme: NbThemeService
  ) {
    this.theme.getJsTheme().pipe(take(1)).subscribe(config => {
        const colors: any = config.variables;
        this.colorScheme = {
          domain: [colors.primaryLight, colors.dangerLight, colors.warningLight],
        };
    });
  }

  ngOnInit() {
  }
}
