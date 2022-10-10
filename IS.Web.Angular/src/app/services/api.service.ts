import { HttpClient, HttpResponse } from '@angular/common/http';
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

  GetDepartmentList():Observable<any>{
    return this.http.get<any>(GlobalConstants.ISAPIUrl + '/Department/GetDepartmentList');
  }

  GetDepartmentByID(internalID:any):Observable<any>{
    return this.http.get<any>(GlobalConstants.ISAPIUrl + '/Department/GetDepartmentByID/' + internalID);
  }

  IsDepartmentNameExist(name:string):Observable<any>{
    return this.http.get<any>(GlobalConstants.ISAPIUrl + '/Department/IsDepartmentNameExist/' + name);
  }

  SaveDepartment(model:DepartmentRequestModel){
    return this.http.post(GlobalConstants.ISAPIUrl + '/Department/SaveDepartment', model);
  }
}
