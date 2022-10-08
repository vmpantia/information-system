import { Component, OnInit } from '@angular/core';
import { Department } from 'src/app/models/department.model';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-view-dep',
  templateUrl: './view-dep.component.html',
  styleUrls: ['./view-dep.component.css']
})
export class ViewDepComponent implements OnInit {

  constructor(private service:ApiService) { }
  
  depList!:any[];
  modalTitle!:string;
  errorMessage!:string;
  depInfo!:Department;
  ActivateAddEditDepComp:boolean=false;

  ngOnInit(): void {
    this.RefreshDepartmentList();
  }

  RefreshDepartmentList(){
    this.service.GetDepartmentList().subscribe(
      (resonse:any) => {
        this.depList = resonse;
      },
      (err) => {
        this.errorMessage = err.message
      }
    )
  }

  EditClick(data:Department){
    this.modalTitle = "Edit Department";
    this.ActivateAddEditDepComp = true;
    
    //Setup Edit Department Info
    this.depInfo = data;
  } 

  AddClick(){
    this.modalTitle = "Add Department";
    this.ActivateAddEditDepComp = true;

    //Setup Add Department Info
    this.depInfo = new Department();
  }

  CloseClick(){
    this.ActivateAddEditDepComp = false;
    this.RefreshDepartmentList();
  }


}
