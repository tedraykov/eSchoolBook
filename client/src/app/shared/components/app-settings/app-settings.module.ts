import { NgModule } from '@angular/core';
import { SettingsComponent } from './settings.component';
import {
   NbButtonModule,
   NbCardModule,
   NbInputModule,
   NbSelectModule,
   NbTabsetModule
} from "@nebular/theme";

@NgModule({
   declarations: [SettingsComponent],
   imports: [
      NbCardModule,
      NbInputModule,
      NbSelectModule,
      NbTabsetModule,
      NbButtonModule
   ],
   entryComponents: [SettingsComponent],
   exports: [SettingsComponent]
})
export class AppSettingsModule {
}
