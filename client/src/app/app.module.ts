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
import { metaReducers, reducers } from './shared/reducers';
import { HttpClientModule } from "@angular/common/http";
import { NbAuthModule, NbPasswordAuthStrategy } from "@nebular/auth";

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
               baseEndpoint: 'http://localhost:5000',
               login: {
                  endpoint: '/account/login',
                  method: 'post'
               }
            })
         ],
         forms: {}
      }),
      LayoutModule,
      NbEvaIconsModule,
      StoreModule.forRoot(reducers, {
         metaReducers,
         runtimeChecks: {
            strictStateImmutability: true,
            strictActionImmutability: true
         }
      })
   ],
   providers: [],
   exports: [],
   bootstrap: [AppComponent]
})
export class AppModule {
}
