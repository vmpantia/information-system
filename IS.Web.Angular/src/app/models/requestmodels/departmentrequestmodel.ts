import { GlobalConstants } from "src/app/common/globalconstants.model";
import { ClientInformation } from "../clientinformation";
import { Department } from "../department.model";

export class DepartmentRequestModel {
    public functionID:string=GlobalConstants.EMPTY_STRING;
    public department:Department=new Department();
    public client:ClientInformation=new ClientInformation();
}
