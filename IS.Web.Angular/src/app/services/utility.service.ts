import { Injectable } from '@angular/core';
import Swal from 'sweetalert2';
import { GlobalConstants } from '../common/globalconstants.model';
import { Department } from '../models/department.model';

@Injectable({
  providedIn: 'root'
})
export class UtilityService {

  constructor() { }

  ValidateDepartment(newDepInfo:Department, isNew:boolean, oldDepInfo:any = undefined):any
  {
    let errorMessages = new Array();
    if(!isNew)
    {
      oldDepInfo = oldDepInfo as Department
      if(newDepInfo.name === oldDepInfo.name &&
         newDepInfo.manager_InternalID === oldDepInfo.manager_InternalID)
      {
        errorMessages.push(GlobalConstants.ERROR_NO_CHANGES);
      }
    }
    if(newDepInfo.name === "")
    {
      errorMessages.push(GlobalConstants.ERROR_DEPARTMENT_NAME_REQUIRED);
    }
    if(newDepInfo.manager_InternalID === GlobalConstants.EMPTY_GUID)
    {
      errorMessages.push(GlobalConstants.ERROR_DEPARTMENT_MANAGER_REQUIRED);
    }
    return errorMessages;
  }
}
