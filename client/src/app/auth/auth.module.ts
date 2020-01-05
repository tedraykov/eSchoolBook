import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from "@angular/router";
import { NbAuthComponent } from "@nebular/auth";
import { LoginComponent } from "./components/login/login.component";
import {
   NbAlertModule,
   NbButtonModule,
   NbCheckboxModule,
   NbInputModule
} from "@nebular/theme";
import { FormsModule } from "@angular/forms";
import { AuthService } from "./services/auth.service";
import { EffectsModule } from "@ngrx/effects";
import { AuthEffects } from "./state/auth.effects";
import { HTTP_INTERCEPTORS } from "@angular/common/http";
import { TokenInterceptor } from "./services/token.interceptor";
import { AuthGuard } from "./guards/auth.guard";
import { StoreModule } from "@ngrx/store";
import { reducer } from "./state/auth.reducer";

const authModuleRoutes: Routes = [
   {
      path: 'auth',
      component: NbAuthComponent,
      children: [
         {
            path: 'login',
            component: LoginComponent,
         },
         {
            path: '',
            pathMatch: 'prefix',
            redirectTo: 'login'
         }
      ],
   }
];

@NgModule({
   declarations: [LoginComponent],
   imports: [
      CommonModule,
      RouterModule.forChild(authModuleRoutes),
      StoreModule.forFeature('auth', reducer),
      EffectsModule.forFeature([AuthEffects]),
      NbAlertModule,
      FormsModule,
      NbInputModule,
      NbCheckboxModule,
      NbButtonModule
   ],
   providers: [
      AuthService,
      AuthEffects,
      {
         provide: HTTP_INTERCEPTORS,
         useClass: TokenInterceptor,
         multi: true
      },
      AuthGuard
   ]
})
export class AuthModule {
}
