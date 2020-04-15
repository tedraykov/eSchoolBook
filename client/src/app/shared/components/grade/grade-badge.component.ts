import { Component, Input, OnInit } from '@angular/core';

@Component({
   selector: 'app-grade-badge',
   templateUrl: './grade-badge.html',
   styleUrls: ['./grade-badge.scss']
})
export class GradeBadgeComponent implements OnInit {
   @Input() grade: string;

   constructor() {
   }

   ngOnInit() {
   }

}
