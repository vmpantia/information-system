import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { GlobalConstants } from 'src/app/common/globalconstants.model';
import { Department } from 'src/app/models/department.model';
import { DepartmentRequestModel } from 'src/app/models/requestmodels/departmentrequestmodel';
import { ClientInformation } from 'src/app/models/clientinformation';
import { ApiService } from 'src/app/services/api.service';
import { DepartmentService } from 'src/app/services/department.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-add-edit-dep',
  templateUrl: './add-edit-dep.component.html',
  styleUrls: ['./add-edit-dep.component.css']
})
export class AddEditDepComponent implements OnInit {

  constructor(private apiService:ApiService,
              private depService:DepartmentService) { }

  @Input()depInfo:Department;
  @Output()Reload = new EventEmitter();

  disableControl:boolean = false;
  errorMessages = new Array();
  
  newDepInfo:Department = new Department();
  clientInfo:ClientInformation = new ClientInformation();

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

    //Check if the transaction is Add or Edit
    let isNew = this.newDepInfo.internalID === GlobalConstants.EMPTY_GUID ? true : false;

    //Set functionID based on Add or Edit
    functionID = isNew ? GlobalConstants.FUNCTIONID_DEPARTMENT_ADD_ADMIN : GlobalConstants.FUNCTIONID_DEPARTMENT_CHANGE_ADMIN;

    //Validate New Department Info
    if(isNew)
    {
      this.newDepInfo.createdDate = new Date();
      this.errorMessages = this.depService.ValidateDepartment(this.newDepInfo, isNew);
    }
    else
    {
      this.newDepInfo.modifiedDate = new Date();
      this.errorMessages = this.depService.ValidateDepartment(this.newDepInfo, isNew, this.depInfo);
    }
    
    //Check if there's a error
    if(this.errorMessages.length > 0)
    {
      this.disableControl = false;
      return;
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
    this.apiService.SaveDepartment(depReqModel)
    .subscribe(
      (reponse:any) => {
        Swal.fire(GlobalConstants.SUCCESS_SAVE,
                  reponse + GlobalConstants.SUCCESS_TRANSACTION,
                  "success").then(res => {
                    this.disableControl = false;
                    this.Reload.emit();
                  });
      },
      (err) => {
        this.disableControl = false;
        this.errorMessages.push(GlobalConstants.ERROR_SAVING_DEPARTMENT)
      }
    )
  }
}
