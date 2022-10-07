import { ClientInformation } from "../clientinformation";
import { Department } from "../department.model";

export class DepartmentRequestModel {
    public functionID!:string;
    public department!:Department;
    public client!:ClientInformation;
}
