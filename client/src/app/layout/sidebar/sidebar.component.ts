import {
   Component,
   EventEmitter,
   OnDestroy,
   OnInit,
   Output
} from '@angular/core';
import { NbMenuBag, NbMenuItem, NbMenuService } from "@nebular/theme";
import { filter, tap } from "rxjs/operators";
import { Subscription } from "rxjs";

@Component({
   selector: 'app-sidebar',
   templateUrl: './sidebar.html',
   styleUrls: ['./sidebar.scss']
})
export class SidebarComponent implements OnInit, OnDestroy {
   @Output() sidebarStateChanged: EventEmitter<void>;

   menuItemClickedSubscription: Subscription;
   menuItems: NbMenuItem[] = [
      {title: '', icon: 'menu-outline'},
      {title: 'users', icon: 'people-outline', link: 'users'},
      {
         title: 'teacher', link: 'teacher', children: [
            {title: 'subjects list', link: 'teacher/subject'},
            {title: 'subject details', link: 'teacher/subject/1'}
         ]
      }
   ];

   constructor(private menuService: NbMenuService) {
      this.sidebarStateChanged = new EventEmitter<void>();
   }

   ngOnInit() {
      this.menuItemClickedSubscription = this.menuService.onItemClick().pipe(
            filter((bag: NbMenuBag) =>
                  bag.item.icon === "menu-outline"
            ),
            tap(this.onSidenavHamburgerClicked.bind(this))
      ).subscribe();
   }

   onSidenavHamburgerClicked(): void {
      this.sidebarStateChanged.emit();
   };

   ngOnDestroy(): void {
      this.menuItemClickedSubscription.unsubscribe();
   }
}
