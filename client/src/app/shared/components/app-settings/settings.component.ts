import { Component, OnInit } from '@angular/core';
import { NbDialogRef, NbThemeService } from "@nebular/theme";

@Component({
   selector: 'app-settings',
   templateUrl: './settings.html',
   styleUrls: ['./settings.scss']
})
export class SettingsComponent implements OnInit {
   selectedTheme: string;

   constructor(
         private themeService: NbThemeService,
         protected dialogRef: NbDialogRef<SettingsComponent>) {
   }

   ngOnInit() {
      this.selectedTheme = this.themeService.currentTheme;
   }

   save() {
      const currentTheme = (this.themeService.currentTheme);
      if (this.selectedTheme !== currentTheme) {
         this.themeService.changeTheme(this.selectedTheme);
      }
   }

   saveAndClose() {
      this.save();
      this.close();
   }

   close() {
      this.dialogRef.close();
   }
}
