import { Component, Input, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-dep',
  templateUrl: './add-edit-dep.component.html',
  styleUrls: ['./add-edit-dep.component.css']
})
export class AddEditDepComponent implements OnInit {

  constructor(private service:SharedService) { }

  @Input() dep:any;
  internalID!:string;
  name!:string;

  ngOnInit(): void {
    this.internalID = this.dep.internalID;
    this.name = this.dep.name;
  }

  SaveDeparment(){
    var val = {
      functionID:"01A01",
      internalID:"3fa85f64-5717-4562-b3fc-2c963f66afa6",
      name:this.name,
      manager_InternalID:"3fa85f64-5717-4562-b3fc-2c963f66afa6",
      status: 0,
      createdDate: "2022-10-06",
      modifiedDate: "2022-10-06",
      client: {
        userID:"",
        name:"Tae",
        isAdmin: true,
        isManager: true
      }
    }

    this.service.SaveDepartment(val).subscribe(
      res => { 
        alert("Susccessfully Saved!");
      },
      error => {
        alert(error.ToString());
      });
  }
}
