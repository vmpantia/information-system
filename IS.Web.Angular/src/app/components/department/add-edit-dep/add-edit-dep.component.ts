import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { GlobalConstants } from 'src/app/common/globalconstants.model';
import { Department } from 'src/app/models/department.model';
import { DepartmentRequestModel } from 'src/app/models/requestmodels/departmentrequestmodel';
import { ClientInformation } from 'src/app/models/clientinformation';
import { ApiService } from 'src/app/services/api.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-add-edit-dep',
  templateUrl: './add-edit-dep.component.html',
  styleUrls: ['./add-edit-dep.component.css']
})
export class AddEditDepComponent implements OnInit {

  constructor(private service:ApiService) { }

  @Input() depInfo!:Department;
  
  newDepInfo = new Department();
  clientInfo = new ClientInformation();

  disableControl:boolean = false;

  ngOnInit(): void {;
    this.newDepInfo.internalID = this.depInfo.internalID;
    this.newDepInfo.name = this.depInfo.name;
    this.newDepInfo.manager_InternalID = this.depInfo.manager_InternalID;
    this.newDepInfo.status = this.depInfo.status;
    this.newDepInfo.createdDate = this.depInfo.createdDate;
    this.newDepInfo.modifiedDate = this.depInfo.modifiedDate;
  }

  SaveDepartment(){
    this.disableControl = true;

    //Initialize Variables
    let functionID:string;
    let depReqModel = new DepartmentRequestModel();

    if(this.newDepInfo.name == "" || this.newDepInfo.name == undefined)
    {
      this.disableControl = false;
      Swal.fire("Department Name",
                "This field is required.",
                "warning");
      return;
    }

    if(this.newDepInfo.internalID == undefined) {
      functionID = GlobalConstants.FUNCTIONID_DEPARTMENT_ADD_ADMIN;
      this.newDepInfo.createdDate = new Date();
    }
    else{
      functionID = GlobalConstants.FUNCTIONID_DEPARTMENT_CHANGE_ADMIN;
      this.newDepInfo.modifiedDate = new Date();
    }

    //Prepare Variables
    this.clientInfo.name = "Vincent";
    this.clientInfo.userID = GlobalConstants.EMPTY_GUID;
    this.clientInfo.isAdmin = true;
    this.clientInfo.isManager = false;

    depReqModel.functionID = functionID;
    depReqModel.department = this.newDepInfo;
    depReqModel.client = this.clientInfo;

    //Save Department Request Model
    this.service.SaveDepartment(depReqModel)
    .subscribe(
      (reponse:any) => {
        this.disableControl = false;
        Swal.fire("Save Successfully",
                  reponse + " is your Request ID for your transaction.",
                  "success");
      },
      (err) => {
        this.disableControl = false;
        Swal.fire("Error in Saving Department",
                  err.message,
                  "error");
      }
    )

  }
}
