import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { GlobalConstants } from 'src/app/common/globalconstants.model';
import { Department } from 'src/app/models/department.model';
import { DepartmentRequestModel } from 'src/app/models/requestmodels/departmentrequestmodel';
import { ClientInformation } from 'src/app/models/clientinformation';
import { ApiService } from 'src/app/services/api.service';
import { UtilityService } from 'src/app/services/utility.service';
import Swal from 'sweetalert2';

//Icons
import { faFloppyDisk } from '@fortawesome/free-solid-svg-icons';

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
      this.errorMessages = this.utility.ValidateDepartment(this.newDepInfo, isNew);
    }
    else
    {
      this.newDepInfo.modifiedDate = new Date();
      this.errorMessages = this.utility.ValidateDepartment(this.newDepInfo, isNew, this.depInfo);
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
    this.api.SaveDepartment(depReqModel)
    .subscribe(
      (response:any) => {
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
              text: response + GlobalConstants.SUCCESS_SAVE_TRANSACTION_TEXT,
              icon: "success",
              confirmButtonColor: GlobalConstants.COLOR_BLUE
            }).then(() => {
              this.Reload.emit();
            });
          }
          this.disableControl = false;
        })
      },
      (err) => {
        this.disableControl = false;
        this.errorMessages.push(GlobalConstants.ERROR_SAVING_DEPARTMENT);
      }
    )
  }
}
