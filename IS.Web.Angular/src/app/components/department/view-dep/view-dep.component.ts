import { Component, OnInit } from '@angular/core';
import { Department } from 'src/app/models/department.model';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-view-dep',
  templateUrl: './view-dep.component.html',
  styleUrls: ['./view-dep.component.css']
})
export class ViewDepComponent implements OnInit {

  constructor(public api:ApiService) { }
  
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
        this.depList = res as Department[]
      },
      (err) => {
        this.errorMessage = err.message
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
