import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { GlobalConstants } from 'src/app/common/globalconstants.model';
import { DepartmentRequestModel } from '../models/requestmodels/departmentrequestmodel';
import { Department } from '../models/department.model';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http:HttpClient) { }

  GetDepartmentList():Observable<Department[]>{
    return this.http.get<Department[]>(GlobalConstants.ISAPIUrl + '/Department/GetDepartmentList');
  }

  GetDepartmentByID(internalID:any):Observable<Department>{
    return this.http.get<Department>(GlobalConstants.ISAPIUrl + '/Department/GetDepartmentByID/' + internalID);
  }

  SaveDepartment(model:DepartmentRequestModel){
    return this.http.post(GlobalConstants.ISAPIUrl + '/Department/SaveDepartment', model);
  }
}
