export class GlobalConstants {
    public static ISAPIUrl:string = "https://localhost:7193/api";
    public static EMPTY_GUID:string = "00000000-0000-0000-0000-000000000000";
    public static EXEC_DATE:Date = new Date();

    //Department Function IDs
    public static FUNCTIONID_DEPARTMENT_ADD_ADMIN      = "01A01";
    public static FUNCTIONID_DEPARTMENT_CHANGE_ADMIN   = "01C01";
    public static FUNCTIONID_DEPARTMENT_DELETE_ADMIN   = "01D01";

    public static SUCCESS_TRANSACTION = " is your Request ID for your transaction.";
    public static SUCCESS_SAVE = "Save Successfully";

    public static ERROR_SAVING_DEPARTMENT = "Error in Saving Department, Please try again.";
    public static ERROR_NO_CHANGES = "No changes made";
    public static ERROR_DEPARTMENT_NAME_REQUIRED = "Department Name is Required";
    public static ERROR_DEPARTMENT_MANAGER_REQUIRED = "Select Manager is Required";
}
