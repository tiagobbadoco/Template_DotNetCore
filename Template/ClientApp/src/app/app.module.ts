import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { JwtModule } from "@auth0/angular-jwt";

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ErrorHandlerService } from './shared/services/error-handler.service';
import { NotFoundComponent } from './error-pages/not-found/not-found.component';
import { AuthGuard } from './shared/guards/auth.guard';
import { ForbiddenComponent } from './error-pages/forbidden/forbidden.component';
import { NavHeaderComponent } from './nav-header/nav-header.component';
import { NavFooterComponent } from './nav-footer/nav-footer.component';
import { NavSettingsComponent } from './nav-settings/nav-settings.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    NotFoundComponent,
    ForbiddenComponent,
    NavHeaderComponent,
    NavFooterComponent,
    NavSettingsComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'administration', loadChildren: () => import('./administration/administration.module').then(m => m.AdministrationModule), canActivate: [AuthGuard] },
      { path: 'authentication', loadChildren: () => import('./authentication/authentication.module').then(m => m.AuthenticationModule) },
      { path: 'forbidden', component: ForbiddenComponent },
      { path: '404', component: NotFoundComponent },
      { path: '**', redirectTo: '/404' }
    ]),
    JwtModule.forRoot({
      config: {
        tokenGetter: () => {
          return localStorage.getItem('token');
        },
        whitelistedDomains: ["localhost:5001", "localhost:44346"],
        blacklistedRoutes: []
      }
    })
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorHandlerService,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
