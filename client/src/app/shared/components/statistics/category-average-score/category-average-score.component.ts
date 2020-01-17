import {Component, Input, OnInit} from '@angular/core';
import {StringDoubleModel} from "../../../models/string-double.model";
@Component({
    selector: 'app-category-average-score',
    templateUrl: './category-average-score.component.html',
    styleUrls: ['./category-average-score.component.scss']
})
export class CategoryAverageScoreComponent implements OnInit {
    @Input() category: string;
    @Input() data: Array<StringDoubleModel>;

    constructor() {
    }

    ngOnInit() {
    }

}
