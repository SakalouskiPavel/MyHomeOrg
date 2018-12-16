import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserManagementComponent } from './user-management.component';
import { LoginComponentComponent } from './login-component/login-component.component';
import { UserManagementRoutingModule } from './user-management-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [UserManagementComponent, LoginComponentComponent],
  imports: [
    CommonModule,
    UserManagementRoutingModule,
    FormsModule,
    HttpClientModule
  ]
})
export class UserManagementModule { }
