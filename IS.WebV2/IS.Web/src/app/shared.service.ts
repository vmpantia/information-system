import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Observable} from  'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
readonly APIUrl ="https://localhost:7193/api";

  constructor(private http:HttpClient) { }
  
  GetDepartmentList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/Department/GetDepartmentList');
  }

  GetDepartmentByID(val:any){
    return this.http.get<any>(this.APIUrl+'/Department/GetDeaprtmentByID/', val);
  }

  SaveDepartment(val:any){
    return this.http.post(this.APIUrl+'/Department/SaveDepartment',val);
  }
}
