import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {NbDialogService} from "@nebular/theme";
import {SettingsComponent} from "../../shared/components/app-settings/settings.component";

@Component({
    selector: 'app-header',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
    @Output() sidebarStateChanged: EventEmitter<void>;

    constructor(private dialogService: NbDialogService) {
        this.sidebarStateChanged = new EventEmitter<void>();
    }

    ngOnInit() {
    }

    openSettings() {
        this.dialogService.open(SettingsComponent)
    }
}
