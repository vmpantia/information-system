import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { GlobalConstants } from '../common/globalconstants.model';
import { Department } from '../models/department.model';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class UtilityService {

  constructor(private api:ApiService) { }

  ValidateDepartment(newDepInfo:Department, isNew:boolean, oldDepInfo:any = undefined):any
  {
    let errorMessages:any = new Array();

    if(!isNew)
    {
      //Check if there is a changes in Department Information
      oldDepInfo = oldDepInfo as Department
      if(newDepInfo.name === oldDepInfo.name &&
         newDepInfo.manager_InternalID === oldDepInfo.manager_InternalID)
      {
        errorMessages.push(GlobalConstants.ERROR_NO_CHANGES);
      }
    }

    //Check if Department Name is Empty
    if(newDepInfo.name === GlobalConstants.EMPTY_STRING)
    {
      errorMessages.push(GlobalConstants.ERROR_DEPARTMENT_NAME_REQUIRED);
    }

    //Check if Department Manager is Empty
    if(newDepInfo.manager_InternalID === GlobalConstants.EMPTY_STRING || 
       newDepInfo.manager_InternalID === GlobalConstants.EMPTY_GUID)
    {
       errorMessages.push(GlobalConstants.ERROR_DEPARTMENT_MANAGER_REQUIRED);
    }

    return errorMessages;
  }
}
