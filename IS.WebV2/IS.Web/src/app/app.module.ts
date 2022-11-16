import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DepartmentComponent } from './department/department.component';
import { AddEditDepComponent } from './department/add-edit-dep/add-edit-dep.component';
import { ViewDepComponent } from './department/view-dep/view-dep.component';
import { EmployeeComponent } from './employee/employee.component';
import { ViewEmpComponent } from './employee/view-emp/view-emp.component';
import { AddEditEmpComponent } from './employee/add-edit-emp/add-edit-emp.component';
import { SharedService } from './shared.service';

import {HttpClientModule} from '@angular/common/http';
import {FormsModule,ReactiveFormsModule} from  '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [
    AppComponent,
    DepartmentComponent,
    AddEditDepComponent,
    ViewDepComponent,
    EmployeeComponent,
    ViewEmpComponent,
    AddEditEmpComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule
  ],
  providers: [SharedService],
  bootstrap: [AppComponent]
})
export class AppModule { }
