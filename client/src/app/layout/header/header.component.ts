import { Component, OnInit } from '@angular/core';
import { NbDialogService } from "@nebular/theme";
import { SettingsComponent } from "../../shared/components/app-settings/settings.component";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

   constructor(private dialogService: NbDialogService) {
   }

  ngOnInit() {
  }

   openSettings() {
      this.dialogService.open(SettingsComponent)
   }
}
