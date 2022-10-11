export class GlobalConstants {
    public static ISAPIUrl:string = "https://localhost:7193/api";
    public static EMPTY_GUID:string = "00000000-0000-0000-0000-000000000000";
    public static EMPTY_STRING:string = "";
    public static EXEC_DATE:Date = new Date();

    //Department Function IDs
    public static FUNCTIONID_DEPARTMENT_ADD_ADMIN      = "01A01";
    public static FUNCTIONID_DEPARTMENT_CHANGE_ADMIN   = "01C01";
    public static FUNCTIONID_DEPARTMENT_DELETE_ADMIN   = "01D01";

    public static CONFIRM_SAVE_DEPARTMENT_TITLE = "Save Department";
    public static CONFIRM_SAVE_DEPARTMENT_TEXT = "Are you sure you want to save this record?";

    public static SUCCESS_SAVE_TRANSACTION_TITLE = "Save Successfully";
    public static SUCCESS_SAVE_TRANSACTION_TEXT = "Your transaction has been saved in our database";

    public static ERROR_NO_CHANGES = "No changes made";
    public static ERROR_DEPARTMENT_NAME_REQUIRED = "Department Name is Required";
    public static ERROR_DEPARTMENT_NAME_EXIST = "Department Name is already Exist";
    public static ERROR_DEPARTMENT_MANAGER_REQUIRED = "Select Manager is Required";

    public static COLOR_BLUE   = "#3085d6";
    public static COLOR_RED    = "#d33";
}
