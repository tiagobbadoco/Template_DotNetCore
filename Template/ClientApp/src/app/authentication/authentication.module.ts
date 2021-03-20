import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { RegisterUserComponent } from './register-user/register-user.component';
import { PrivacyComponent } from './privacy/privacy.component';
import { AuthGuard } from '../shared/guards/auth.guard';
import { AdminGuard } from '../shared/guards/admin.guard';



@NgModule({
  declarations: [LoginComponent, RegisterUserComponent, PrivacyComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule.forChild([
      { path: 'register', component: RegisterUserComponent },
      { path: 'login', component: LoginComponent },
      { path: 'privacy', component: PrivacyComponent, canActivate: [AuthGuard, AdminGuard] }
    ])
  ]
})
export class AuthenticationModule { }
