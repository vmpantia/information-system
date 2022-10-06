import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-view-dep',
  templateUrl: './view-dep.component.html',
  styleUrls: ['./view-dep.component.css']
})
export class ViewDepComponent implements OnInit {

  constructor(private service:SharedService) { }

  DepartmentList:any=[];

  ModalTitle!: string;
  ActivateAddEditDepComp:boolean=false;
  dep:any;

  ngOnInit(): void {
    this.refreshDepartmentList();
  }

  refreshDepartmentList(){
    this.service.GetDepartmentList().subscribe(
      data =>{
        this.DepartmentList=data;
      }
    );
  }

  addClick(){
    this.dep={
      DepartmentID:0,
      DepartmentName:"",
      Status:0
    }
    this.ModalTitle="Add Department";
    this.ActivateAddEditDepComp=true;
  }

  closeClick(){
    this.ActivateAddEditDepComp=false;
    this.refreshDepartmentList()
  }

}
