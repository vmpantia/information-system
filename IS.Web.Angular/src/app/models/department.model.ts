import { GlobalConstants } from "../common/globalconstants.model";

export class Department {
    public internalID:any=GlobalConstants.EMPTY_GUID;
    public name:string=GlobalConstants.EMPTY_STRING;
    public manager_InternalID:any=GlobalConstants.EMPTY_GUID;
    public status:number=0;
    public createdDate:Date;
    public modifiedDate:Date;
}
