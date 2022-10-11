import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';

//Models
import { GlobalConstants } from 'src/app/common/globalconstants.model';
import { Department } from 'src/app/models/department.model';
import { DepartmentRequestModel } from 'src/app/models/requestmodels/departmentrequestmodel';
import { ClientInformation } from 'src/app/models/clientinformation';

//Services
import { ApiService } from 'src/app/services/api.service';
import { UtilityService } from 'src/app/services/utility.service';
import Swal from 'sweetalert2';

//Icons
import { faFloppyDisk } from '@fortawesome/free-solid-svg-icons';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-add-edit-dep',
  templateUrl: './add-edit-dep.component.html',
  styleUrls: ['./add-edit-dep.component.css']
})
export class AddEditDepComponent implements OnInit {

  constructor(private api:ApiService,
              private utility:UtilityService) { }
              
  //Icons
  faFloppyDisk = faFloppyDisk;
  
  @Input()depInfo:Department;
  @Output()Reload = new EventEmitter();

  disableControl:boolean = false;
  errorMessages = new Array();
  
  newDepInfo:Department = new Department();
  clientInfo:ClientInformation = new ClientInformation();

  managerList:any[];

  ngOnInit(): void {;
    this.newDepInfo.internalID = this.depInfo.internalID;
    this.newDepInfo.name = this.depInfo.name;
    this.newDepInfo.manager_InternalID = this.depInfo.manager_InternalID;
    this.newDepInfo.status = this.depInfo.status;
    this.newDepInfo.createdDate = this.depInfo.createdDate;
    this.newDepInfo.modifiedDate = this.depInfo.modifiedDate;
    
    this.managerList = [  
      {internalID : "45261be5-1029-4dda-8fbb-84c407c38a83", name : "Vincent Pogi"},  
      {internalID : "44474bf3-fa3c-4ff7-905f-586d7ee904e6", name : "Vincent Handsome"},  
      {internalID : "2ea87b71-1c27-4d47-b0c5-cd7312d51ffe", name : "Vincent Wala lang"}  
    ];  
  }

  SaveDepartment(){
    //Reset Error Messages
    this.errorMessages = new Array();
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
      this.newDepInfo.createdDate = new Date();
    else
      this.newDepInfo.modifiedDate = new Date();

    //Prepare Variables
    this.clientInfo.name = "Vincent";
    this.clientInfo.userID = GlobalConstants.EMPTY_GUID;
    this.clientInfo.isAdmin = true;
    this.clientInfo.isManager = false;

    depReqModel.functionID = functionID;
    depReqModel.department = this.newDepInfo;
    depReqModel.client = this.clientInfo;

    //Save Department Request Model
    this.api.SaveDepartment(depReqModel)
    .subscribe(
      (res:any) => {
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
            Swal.fire( {
              title: GlobalConstants.SUCCESS_SAVE_TRANSACTION_TITLE, 
              text: GlobalConstants.SUCCESS_SAVE_TRANSACTION_TEXT,
              icon: "success",
              confirmButtonColor: GlobalConstants.COLOR_BLUE
            }).then(() => {
              this.Reload.emit();
            });
          }
          this.disableControl = false;
        })
      },
      (err:HttpErrorResponse) => {
        this.disableControl = false;
        this.errorMessages.push(err.error);
      }
    )
  }
}
