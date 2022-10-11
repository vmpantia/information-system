namespace IS.Api.Models
{
    public class Constants
    {
        public const string NA = "N/A";
        public const string DASH = "-";
        public const char ZERO = '0';

        #region Table Status
        public const int STATUS_ENABLED = 0;
        public const int STATUS_DISABLED = 1;
        public const int STATUS_DELETION = 2;

        public const string STATUS_ENABLED_STR = "Enabled";
        public const string STATUS_DISABLED_STR = "Disabled";
        public const string STATUS_DELETION_STR = "Deletion";
        #endregion

        #region Request Status
        public const string REQUEST_STATUS_COMPLETED = "A2";
        #endregion

        #region Error Message
        public const string ERROR_DATA_NOT_FOUND = "Data NOT found in the System or Database";
        public const string ERROR_INVALID_FUNCTIONID = "Invalid FunctionId";
        public const string ERROR_INVALID_OBJECTS = "The 2 object type doesn't match";
        #endregion

        #region Employee FunctionId
        public const string FUNCTIONID_EMPLOYEE_ADD_ADMIN      = "00A01";
        public const string FUNCTIONID_EMPLOYEE_ADD_MANAGER    = "00A02";
        public const string FUNCTIONID_EMPLOYEE_ADD_USER       = "00A03";

        public const string FUNCTIONID_EMPLOYEE_CHANGE_ADMIN   = "00C01";
        public const string FUNCTIONID_EMPLOYEE_CHANGE_MANAGER = "00C02";
        public const string FUNCTIONID_EMPLOYEE_CHANGE_USER    = "00C03";

        public const string FUNCTIONID_EMPLOYEE_DELETE_ADMIN   = "00D01";
        public const string FUNCTIONID_EMPLOYEE_DELETE_MANAGER = "00D02";
        public const string FUNCTIONID_EMPLOYEE_DELETE_USER    = "00D03";
        #endregion

        #region Department FunctionId
        public const string FUNCTIONID_DEPARTMENT_ADD_ADMIN      = "01A01";
        public const string FUNCTIONID_DEPARTMENT_CHANGE_ADMIN   = "01C01";
        public const string FUNCTIONID_DEPARTMENT_DELETE_ADMIN   = "01D01";
        #endregion

        #region Department Views
        public const string VIEW_DEPARTMENT_INDEX = "Index";
        public const string VIEW_DEPARTMENT_CREATE = "Create";
        public const string VIEW_DEPARTMENT_EDIT = "Edit";
        #endregion

        #region Department Changeable Values 
        public const string DEPARTMENT_NAME = "Name";
        public const string DEPARTMENT_MANAGER = "Manager_InternalId";
        public const string DEPARTMENT_STATUS = "Status";
        public const string DEPARTMENT_MODIFIEDDATE = "ModifiedDate";
        #endregion

        #region Position FunctionId
        public const string FUNCTIONID_POSITION_ADD_ADMIN      = "02A01";
        public const string FUNCTIONID_POSITION_CHANGE_ADMIN   = "02C01";
        public const string FUNCTIONID_POSITION_DELETE_ADMIN   = "02D01";
        #endregion
    }
}
