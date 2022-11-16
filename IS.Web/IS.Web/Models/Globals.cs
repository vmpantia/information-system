namespace IS.Web.Models
{
    public static class Globals
    {
        public static DateTime EXEC_DATE = DateTime.Now.Date;
        public static string REQUESTID_FIRST_LAYER = "R";
        public static string REQUESTID_SECOND_LAYER = DateTime.Now.ToString("yyyyMMdd");
        public static string REQUESTID_THIRD_LAYER_DEFAULT = "000001";
        public static string REQUESTID_DEFAULT = String.Concat(REQUESTID_FIRST_LAYER, REQUESTID_SECOND_LAYER, REQUESTID_THIRD_LAYER_DEFAULT);
        public static int REQUESTID_THIRD_LAYER_LENGTH = REQUESTID_THIRD_LAYER_DEFAULT.Length;
        public static int REQUESTID_DEFAULT_LENGTH = REQUESTID_DEFAULT.Length;
    }
}
