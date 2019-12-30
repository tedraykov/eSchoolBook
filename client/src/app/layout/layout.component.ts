import { Component, OnInit } from '@angular/core';

@Component({
   selector: 'app-layout',
   templateUrl: './layout.html',
   styleUrls: ['./layout.scss']
})
export class LayoutComponent implements OnInit {
   sidebarState = 'expanded';

   constructor() {
   }

   ngOnInit() {
   }

   onSidebarStateChanged() {
      this.sidebarState = this.sidebarState === 'expanded' ? 'compacted' : 'expanded';
   }
}
