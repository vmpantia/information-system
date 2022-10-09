import { ClientInformation } from "../clientinformation";
import { Department } from "../department.model";

export class DepartmentRequestModel {
    public functionID:string="";
    public department:Department=new Department();
    public client:ClientInformation=new ClientInformation();
}
