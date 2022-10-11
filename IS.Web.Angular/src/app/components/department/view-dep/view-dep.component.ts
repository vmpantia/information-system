import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

//Models
import { Department } from 'src/app/models/department.model';

//Services
import { ApiService } from 'src/app/services/api.service';

//Icons
import { faBuilding, faFolderPlus, faPenToSquare, faTrash } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-view-dep',
  templateUrl: './view-dep.component.html',
  styleUrls: ['./view-dep.component.css']
})
export class ViewDepComponent implements OnInit {

  constructor(public api:ApiService) { }
  
  //Icons
  faBuilding = faBuilding;
  faFolderPlus = faFolderPlus;
  faPenToSquare = faPenToSquare;
  faTrash = faTrash;

  depList:Department[];
  depInfo:Department;
  errorMessage:string;

  modalTitle:string;

  ngOnInit(): void {
    this.RefreshDepartmentList();
  }

  RefreshDepartmentList(){
    this.api.GetDepartmentList().subscribe(
      (res:any) => {
        this.depList = res as Department[];
      },
      (err:HttpErrorResponse) => {
        this.errorMessage = err.error;
      }
    )
  }
  
  EditDepartment(data:Department){
    this.modalTitle = "Edit Department";
    
    //Setup Edit Department Info
    this.depInfo = Object.assign({}, data);
  } 

  AddDepartment(){
    this.modalTitle = "Add Department";

    //Setup Add Department Info
    this.depInfo = new Department();
  }

  CloseDepartmentForm(){
    this.Reload();
  }

  Reload(){
    window.location.reload();
    this.depInfo = new Department();
  }

}
