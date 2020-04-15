import { Component, OnInit } from '@angular/core';
import { UserModel, UserService } from "../../shared/services/user.service";
import { TreeNode } from "../../shared/tree-grid/tree-node";
import { map } from "rxjs/operators";
import { Observable } from "rxjs";
import { Router } from "@angular/router";

@Component({
   selector: 'app-users-list',
   templateUrl: './users-list.html',
   styleUrls: ['./users-list.scss']
})
export class UsersListComponent implements OnInit {
   allColumns = [ 'fullName', 'role' ];
   tableData$: Observable<TreeNode<UserModel>[]>;

   constructor(
         private userService: UserService,
         private router: Router
   ) {
   }

   ngOnInit() {
      this.tableData$ = this.userService.getUsers$().pipe(
            map((users: UserModel[]) => {
               return users.map(user =>
                  <TreeNode<UserModel>>{data: user}
               )
            })
      );

   }

   navigateToUser(user: UserModel) {
      this.router.navigate(['users', user.schoolUserId]).then();
   }
}
