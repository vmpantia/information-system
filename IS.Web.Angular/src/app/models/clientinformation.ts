import { GlobalConstants } from "../common/globalconstants.model";

export class ClientInformation {
    public userID:any=GlobalConstants.EMPTY_GUID;
    public name:string="";
    public isAdmin:boolean=false;
    public isManager:boolean=false;
}
