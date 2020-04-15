import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {
   NbDialogModule,
   NbMenuModule,
   NbSidebarModule,
   NbThemeModule
} from '@nebular/theme';
import { NbEvaIconsModule } from '@nebular/eva-icons';
import { LayoutModule } from "./layout/layout.module";
import { StoreModule } from '@ngrx/store';
import { HttpClientModule } from "@angular/common/http";
import { NbAuthModule, NbPasswordAuthStrategy } from "@nebular/auth";
import { AuthModule } from "./auth/auth.module";
import { EffectsModule } from "@ngrx/effects";
import { StoreDevtoolsModule } from "@ngrx/store-devtools";
import { environment } from 'src/environments/environment';

@NgModule({
   declarations: [
      AppComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      BrowserAnimationsModule,
      HttpClientModule,
      NbThemeModule.forRoot({name: 'default'}),
      NbSidebarModule.forRoot(),
      NbMenuModule.forRoot(),
      NbDialogModule.forRoot(),
      NbAuthModule.forRoot({
         strategies: [
            NbPasswordAuthStrategy.setup({
               name: 'email',
               baseEndpoint: environment.serverUrl,
               login: {
                  endpoint: '/account/login',
                  method: 'post'
               }
            })
         ],
         forms: {}
      }),
      NbEvaIconsModule,
      AuthModule,
      LayoutModule,
      StoreModule.forRoot({}, {
         runtimeChecks: {
            strictStateImmutability: true,
            strictActionImmutability: true
         }
      }),
      EffectsModule.forRoot([]),
      StoreDevtoolsModule.instrument({
         maxAge: 10
      })
   ],
   providers: [],
   exports: [],
   bootstrap: [AppComponent]
})
export class AppModule {
}
