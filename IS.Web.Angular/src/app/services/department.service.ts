import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import Swal from 'sweetalert2';

//Models
import { GlobalConstants } from '../common/globalconstants.model';
import { DepartmentRequestModel } from '../models/requestmodels/departmentrequestmodel';

//Services
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {

  constructor(private api:ApiService) { }

  SaveDepartment(model:DepartmentRequestModel):any
  {
    //Confirmation for Saving Department
    Swal.fire({
      title: GlobalConstants.CONFIRM_SAVE_DEPARTMENT_TITLE,
      text: GlobalConstants.CONFIRM_SAVE_DEPARTMENT_TEXT,
      icon: "warning",
      confirmButtonText: "Yes",
      confirmButtonColor: GlobalConstants.COLOR_BLUE,
      showCancelButton: true,
      cancelButtonColor: GlobalConstants.COLOR_RED
    }).then((result) => {
      if(result.isConfirmed){
        //Save Department Request Model
        this.api.SaveDepartment(model)
        .subscribe(
          (res:any) => {
            Swal.fire( {
              title: GlobalConstants.SUCCESS_SAVE_TRANSACTION_TITLE, 
              text: GlobalConstants.SUCCESS_SAVE_TRANSACTION_TEXT,
              icon: "success",
              confirmButtonColor: GlobalConstants.COLOR_BLUE
            }).then(() => {
              return "success";
            });
          },
          (err:HttpErrorResponse) => {
            return err.error;
          }
        )
      }
      return "cancel";
    })
  }
}
