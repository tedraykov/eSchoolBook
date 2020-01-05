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

   ],
   providers: [],
   exports: [],
   bootstrap: [AppComponent]
})
export class AppModule {
}
