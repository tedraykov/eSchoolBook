import {
   Component,
   OnDestroy,
   OnInit
} from '@angular/core';
import { NbMenuItem, NbMenuService } from "@nebular/theme";
import { map } from "rxjs/operators";
import {Observable, Subscription} from "rxjs";
import {select, State} from "@ngrx/store";
import {AuthState} from "../../auth/state";
import {selectRole} from "../../auth/state/auth.reducer";
import {menuConfig} from "./config/menu.config";

@Component({
   selector: 'app-sidebar',
   templateUrl: './sidebar.html',
   styleUrls: ['./sidebar.scss']
})
export class SidebarComponent implements OnInit {
   menuItems: Observable<NbMenuItem[]>;

   constructor(
       private menuService: NbMenuService,
       private authState: State<AuthState>) {
   }

   ngOnInit() {
      this.menuItems = this.authState.pipe(
          select(selectRole),
          map(role => menuConfig.get(role) || []));
   }
}
